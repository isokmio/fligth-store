using Microsoft.AspNetCore.Mvc;
using Services.Common.Collection;
using Station.Service.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station.Api.Controllers
{
    [ApiController]
    [Route("api/stations")]
    public class StationController : Controller
    {
        private StationNodeQueryService _stationNodeQueryService;

        private StationController(StationNodeQueryService stationNodeQueryService) 
        {
            _stationNodeQueryService = stationNodeQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<StationNodeDto>> GetAll(int page = 1, int take = 1000, string ids = "")
        {
            IEnumerable<int> stations = null;
            if (!string.IsNullOrEmpty(ids))
            {
                stations = ids.Split(",").Select(x => int.Parse(x));
            }

            return await _stationNodeQueryService.GetAllAsync(page, take, stations);
        }

        [HttpGet("{id}")]
        public async Task<StationNodeDto> GetById(int id)
        {
            return await _stationNodeQueryService.GetByIdAsync(id);
        }

    }
}
