using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Eventful.Contract.V1.Requests;
using Eventful.Contract.V1.Responses;
using Eventful.Logic;
using Eventful.Logic.Queries;
using Eventful.Logic.Results;
using AutoMapper;

namespace Eventful.Api.Controllers
{
    [Route("api/v1/events")]
    public class EventsController : Controller
    {
        public IHandlerFacade HandlerFacade { get; set; }

        public EventsController(IHandlerFacade handlerFacade)
        {
            HandlerFacade = handlerFacade;
        }

        [HttpGet]
        public async Task<SearchEventsResponse> Search(SearchEventsRequest request)
        {
            SearchQuery query = Mapper.Map<SearchQuery>(request);

            SearchQueryResult result = await HandlerFacade.Invoke<SearchQuery, SearchQueryResult>(query);

            return Mapper.Map<SearchEventsResponse>(result);
        }
    }
}