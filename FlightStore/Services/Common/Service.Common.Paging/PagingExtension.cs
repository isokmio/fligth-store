using Microsoft.EntityFrameworkCore;
using Services.Common.Collection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Common.Paging
{
    public static class PagingExtension
    {
        public static async Task<DataCollection<T>> GetPagedAsync<T>(this IQueryable<T> query, int page, int take) 
        {
            int xPage = page;
            page--;

            page *= take;

            var result = new DataCollection<T>
            {
                Items = await query.Skip(page).Take(take).ToListAsync(),
                Size = await query.CountAsync(),
                Page = xPage
            };

            result.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Size) / take));

            return result;
        }
    }
}
