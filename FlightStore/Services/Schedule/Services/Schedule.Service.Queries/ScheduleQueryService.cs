using Microsoft.EntityFrameworkCore;
using Schedule.Persistence.Database;
using Schedule.Service.Queries.DTO;
using Service.Common.Mapper;
using Service.Common.Paging;
using Services.Common.Collection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Service.Queries
{

    public interface IScheduleQueryService
    {
        Task<DataCollection<FlightDto>> GetAllAsync(int page, int take, IEnumerable<int> fligths);
        Task<DataCollection<FlightDto>> GetByFilterAsync(int page, int take, FlightQueryFilterDto filter);
        Task<FlightDto> GetAsync(int id);
    }

    public class ScheduleQueryService : IScheduleQueryService
    {

        ApplicationDbContext _context = null;

        public ScheduleQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<FlightDto>> GetAllAsync(int page, int take, IEnumerable<int> fligths)
        {
            var allFlights = await _context.Flights
                .Where(x => fligths == null || fligths.Contains(x.FlightId))
                .OrderBy(x => x.DepartureDate)
                .GetPagedAsync(page, take);

            return allFlights.MapTo<DataCollection<FlightDto>>();
        }

        public async Task<DataCollection<FlightDto>> GetByFilterAsync(int page, int take, FlightQueryFilterDto filter)
        {
            var filteredFlights = await _context.Flights
                .Where(x => x.DepartureStation == filter.Departure && x.ArrivalStation == filter.Destination && x.DepartureDate > filter.Date)
                .OrderBy(x => x.DepartureDate)
                .GetPagedAsync(page, take);

            return filteredFlights.MapTo<DataCollection<FlightDto>>();
        }

        public async Task<FlightDto> GetAsync(int id)
        {
            var fligth = await _context.Flights
                .SingleAsync(x => x.FlightId == id);

            return fligth.MapTo<FlightDto>();
        }

    }
}
