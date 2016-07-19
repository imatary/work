using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OQC.Web.Core.Helpers
{
    public static class PagedListExtendedExtensions
    {
        public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> superset, int pageNumber, int pageSize)
        {
            return await PagedListExtended<T>.Create(superset, pageNumber, pageSize);
        }
    }
}
