using System.Threading.Tasks;
using Xunit;
using Moq;
using Eventful.Logic;
using Eventful.Logic.Results;
using Eventful.Logic.Queries;
using Eventful.Contract.V1.Requests;
using System;
using AutoMapper;
using System.Collections.Generic;
using Eventful.Logic.Models;
using Eventful.Contract.V1.Responses;
using Eventful.Api.Controllers;

namespace EventfulTest.Api.Controllers
{
    public class SearchEventsControllerTests
    {
        [Fact]
        public async Task ValidEventsSearchController()
        {
            // Arrange
            DateTime now = DateTime.UtcNow;
            SearchEventsRequest request = new SearchEventsRequest
            {
                Address = "TEST",
                Category = "TEST",
                Radius = 1,
                DateStart = now,
                DateEnd = now.AddDays(1)
            };
            SearchQuery query = new SearchQuery
            {
                Address = request.Address,
                Category = request.Category,
                Radius = request.Radius,
                DateStart = request.DateStart,
                DateEnd = request.DateEnd
            };
            List<Event> events = new List<Event>
            {
                new Event{
                    Title="TEST1",
                    Date=now,
                    ImageUri="TEST1",
                    Performers="TEST1",
                    Venue="TEST1"
                },
                 new Event{
                    Title="TEST2",
                    Date=now,
                    ImageUri="TEST2",
                    Performers="TEST2",
                    Venue="TEST2"
                }
            };
            List<EventResponse> eventsResponse = new List<EventResponse>
            {
                new EventResponse{
                    Title=events[0].Title,
                    Date=events[0].Date,
                    ImageUri=events[0].ImageUri,
                    Performers=events[0].Performers,
                    Venue=events[0].Venue
                },
                 new EventResponse{
                    Title=events[1].Title,
                    Date=events[1].Date,
                    ImageUri=events[1].ImageUri,
                    Performers=events[1].Performers,
                    Venue=events[1].Venue
                }
            };
            SearchQueryResult result = new SearchQueryResult(events);
            SearchEventsResponse response = new SearchEventsResponse(eventsResponse);

            Mock<IMapper> mapperMock = new Mock<IMapper>();
            Mock<IHandlerFacade> handlerFacadeMock = new Mock<IHandlerFacade>();

            mapperMock.Setup(m => m.Map<SearchQuery>(request))
                .Returns(query);
            handlerFacadeMock.Setup(hf => hf.Invoke<SearchQuery, SearchQueryResult>(query))
                .ReturnsAsync(result);
            mapperMock.Setup(m => m.Map<SearchEventsResponse>(result))
                .Returns(response);

            var controller = new SearchEventsController(mapperMock.Object, handlerFacadeMock.Object);

            // Act
            var searchResult = await controller.Search(request);

            // Assert
            Assert.Equal(response, searchResult);
            mapperMock.VerifyAll();
            handlerFacadeMock.VerifyAll();
        }
    }
}
