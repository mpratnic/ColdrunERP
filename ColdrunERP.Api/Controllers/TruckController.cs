using ColdrunERP.Api.Requests.Truck;
using ColdrunERP.Api.Responses;
using ColdrunERP.Application.Commands.Truck;
using ColdrunERP.Application.Queries.Truck;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace ColdrunERP.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class TruckController : ControllerBase
    {        
        private readonly ISender _sender;

        public TruckController(ISender sender)
        {            
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromBody]GetTruckListRequest request)
        {
            var getTruckListQuery = new GetTruckListQuery()
            {
                Name = request.Name,
                Description = request.Description,
                StatusId = request.StatusId,
                SortByName = request.SortByName,
                SortByDescription = request.SortByDescription,
                SortByStatus = request.SortByStatus,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            };

            var truckList = await _sender.Send(getTruckListQuery);

            return Ok(truckList.Select(x => new GetTruckListItemResponse { Id = x.Id, Code = x.Code, Name = x.Name, Description = x.Description, StatusName = x.StatusName }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTruckById(int id)
        {
            var truck = await _sender.Send(new GetTruckQuery() { Id = id });

            var truckResponse = new GetTruckResponse
            {
                Code = truck.Code,
                Name = truck.Name,
                Description = truck.Description,
                StatusId = truck.Status.Id,
                StatusName = truck.Status.Name
            };

            return Ok(truckResponse);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTruck([FromBody]CreateTruckRequest request)
        {
            var createTruckCommand = new CreateTruckCommand
            {
                 Code = request.Code,
                 Name = request.Name,
                 Description = request.Description,
                 StatusId = request.StatusId
            };

            return Ok(await _sender.Send(createTruckCommand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookByUd(long id, UpdateTruckRequest request)
        {
            var updateTruckCommand = new UpdateTruckCommand
            {
                Id = id,
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                StatusId = request.StatusId
            };

            return Ok(await _sender.Send(updateTruckCommand));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteTruckCommand = new DeleteTruckCommand
            { 
                Id = id 
            };

            await _sender.Send(deleteTruckCommand);

            return Ok();
        }
    }
}