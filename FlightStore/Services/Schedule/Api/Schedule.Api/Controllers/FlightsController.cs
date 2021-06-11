using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Schedule.Service.Queries;
using Schedule.Service.Queries.DTO;
using Services.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Api.Controllers
{
    [ApiController]
    [Route("/api/flights")]
    public class FlightsController : ControllerBase
    {
        private readonly ILogger<FlightsController> _logger;
        private readonly IScheduleQueryService _scheduleQueryService;

        public FlightsController(ILogger<FlightsController> logger, IScheduleQueryService scheduleQueryService)
        {
            _logger = logger;
            _scheduleQueryService = scheduleQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<FlightDto>> GetAll(int page = 1, int take = 10, string ids = "") 
        {
            IEnumerable<int> fligths = null;
            if (!string.IsNullOrEmpty(ids))
            {
                fligths = ids.Split(",").Select(x => int.Parse(x));
            }

            return await _scheduleQueryService.GetAllAsync(page, take, fligths);
        }

        [HttpPost]
        public async Task<DataCollection<FlightDto>> GetByFilter(FlightQueryFilterDto filter, int page = 1, int take = 10)
        {
            if (!ModelState.IsValid)
                return null;

            return await _scheduleQueryService.GetByFilterAsync(page, take, filter);
        }

        [HttpGet("{id}")]
        public async Task<FlightDto> Get(int id) 
        {
            return await _scheduleQueryService.GetAsync(id);
        }

        [HttpGet("fn/{flightNumber}")]
        public async Task<FlightDto> GetByFlightNumber(string flightNumber)
        {
            return await _scheduleQueryService.GetByFlightNumberAsync(flightNumber);
        }

    }
}
