using Eventful.Logic.Handles;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Eventful.DataAccess.Repositories;
using AutoMapper;
using Eventful.Logic.Queries;
using System;
using Eventful.DataAccess.Entities;
using System.Collections.Generic;
using Eventful.Logic.Models;
using System.Linq;

namespace EventfulTest.Logic.Handlers
{
    public class EventSearchHandlerTests
    {
        [Fact]
        public async Task ValidEventsSearchHandler()
        {
            // Arrange
            DateTime now = DateTime.UtcNow;
            SearchQuery query = new SearchQuery
            {
                Address = "TEST",
                Category = "TEST",
                Radius = 1,
                DateStart = now,
                DateEnd = now.AddDays(1)
            };
            GoogleLocation location = new GoogleLocation()
            {
                Latitude = 100,
                Longitude = 100
            };
            List<EventfulEvent> eventfulEvents = new List<EventfulEvent>
            {
                new EventfulEvent{
                    Title="TEST1",
                    Date=now,
                    ImageUri="TEST1",
                    Performers="TEST1",
                    Venue="TEST1"
                },
                 new EventfulEvent{
                    Title="TEST2",
                    Date=now,
                    ImageUri="TEST2",
                    Performers="TEST2",
                    Venue="TEST2"
                }
            };
            List<Event> events = new List<Event>
            {
                new Event{
                    Title=eventfulEvents[0].Title,
                    Date=eventfulEvents[0].Date,
                    ImageUri=eventfulEvents[0].ImageUri,
                    Performers=eventfulEvents[0].Performers,
                    Venue=eventfulEvents[0].Venue
                },
                 new Event{
                    Title=eventfulEvents[1].Title,
                    Date=eventfulEvents[1].Date,
                    ImageUri=eventfulEvents[1].ImageUri,
                    Performers=eventfulEvents[1].Performers,
                    Venue=eventfulEvents[1].Venue
                }
            };

            Mock<IMapper> mapperMock = new Mock<IMapper>();
            Mock<IGoogleApiRepository> gooogleApiMock = new Mock<IGoogleApiRepository>();
            Mock<IEventfulApiRepository> eventfulApiMock = new Mock<IEventfulApiRepository>();

            gooogleApiMock.Setup(g => g.GetLocation(query.Address))
                .ReturnsAsync(location);
            eventfulApiMock.Setup(e => e.GetEvents(location.Latitude, location.Longitude, query.Radius, query.DateStart, query.DateEnd, query.Category))
                .ReturnsAsync(eventfulEvents);
            mapperMock.Setup(m => m.Map<List<Event>>(eventfulEvents))
                .Returns(events);

            EventSearchHandler handler = new EventSearchHandler(mapperMock.Object, gooogleApiMock.Object, eventfulApiMock.Object);

            // Act
            var result = await handler.DoWork(query);

            // Assert
            Assert.Equal(2, result.Events.ToList().Count);
            gooogleApiMock.VerifyAll();
            eventfulApiMock.VerifyAll();
            mapperMock.VerifyAll();
        }
    }
}
