using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Eventful.Contract.V1.Requests;
using Eventful.Contract.V1.Responses;
using Eventful.Logic;
using Eventful.Logic.Queries;
using Eventful.Logic.Results;
using AutoMapper;
using Eventful.Api.Filters;

namespace Eventful.Api.Controllers
{
    [Route("api/v1/events/search")]
    [ValidateModel]
    public class SearchEventsController : Controller
    {
        public IHandlerFacade HandlerFacade { get; set; }

        public SearchEventsController(IHandlerFacade handlerFacade)
        {
            HandlerFacade = handlerFacade;
        }

        [HttpPost]
        public async Task<SearchEventsResponse> Search([FromBody] SearchEventsRequest request)
        {
            SearchQuery query = Mapper.Map<SearchQuery>(request);

            SearchQueryResult result = await HandlerFacade.Invoke<SearchQuery, SearchQueryResult>(query);

            return Mapper.Map<SearchEventsResponse>(result);
        }
    }
}