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
        private IHandlerFacade _handlerFacade;
        private IMapper _mapper;

        public SearchEventsController(IMapper mapper, IHandlerFacade handlerFacade)
        {
            _mapper = mapper;
            _handlerFacade = handlerFacade;
        }

        [HttpPost]
        public async Task<SearchEventsResponse> Search([FromBody] SearchEventsRequest request)
        {
            SearchQuery query = _mapper.Map<SearchQuery>(request);

            SearchQueryResult result = await _handlerFacade.Invoke<SearchQuery, SearchQueryResult>(query);

            return _mapper.Map<SearchEventsResponse>(result);
        }
    }
}