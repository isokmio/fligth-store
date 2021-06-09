using Microsoft.EntityFrameworkCore;
using Service.Common.Mapper;
using Service.Common.Paging;
using Services.Common.Collection;
using Station.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Station.Service.Queries
{

    public interface IStationNodeQueryService 
    {
        Task<DataCollection<StationNodeDto>> GetAllAsync(int page, int take, IEnumerable<int> stations);

        Task<StationNodeDto> GetByIdAsync(int id);
    }

    public class StationNodeQueryService: IStationNodeQueryService
    {
        private ApplicationDbContext _context = null;

        public StationNodeQueryService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<DataCollection<StationNodeDto>> GetAllAsync(int page, int take, IEnumerable<int> stations) {
            var collection = await _context.Stations
                .OrderBy(x => x.Code)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<StationNodeDto>>();
        }

        public async Task<StationNodeDto> GetByIdAsync(int id)
        {
            var collection = await _context.Stations
                .SingleAsync(x => x.StationNodeId == id);

            return collection.MapTo<StationNodeDto>();
        }
    }
}
