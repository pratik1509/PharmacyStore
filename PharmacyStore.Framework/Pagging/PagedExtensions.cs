using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Framework.Pagging
{

    public static class PagedExtensions
    {
        private static int ValidatePagePropertiesAndGetSkipCount(PagingConfig pagingConfig)
        {
            if (pagingConfig.Page < 1)
            {
                pagingConfig.Page = 1;
            }

            if (pagingConfig.PageSize < 0)
            {
                pagingConfig.PageSize = 10;
            }

            if (pagingConfig.PageSize > 100)
            {
                pagingConfig.PageSize = 100;
            }

            return pagingConfig.PageSize * (pagingConfig.Page - 1);
        }

        public static async Task<IPagedList<TQ>> ToPagedListAsync<T, TQ>(this IAggregateFluent<TQ> query, int page = 1, int pageSize = 0)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            var pagingConfig = new PagingConfig(page, pageSize);
            var skipCount = ValidatePagePropertiesAndGetSkipCount(pagingConfig);

            var data = await query
                .Skip(skipCount)
                .Limit(pagingConfig.PageSize)
                .ToListAsync();

            if (skipCount > 0 && data.Count == 0)
            {
                // Requested page has no records, just return the first page
                pagingConfig.Page = 1;
                data = await query
                    .Limit(pagingConfig.PageSize)
                    .ToListAsync();
            }

            return new PagedList<TQ>(data, pagingConfig.Page, pagingConfig.PageSize, (long)query.Group("id:{1},Total:{$sum:1}").ToList().First().GetValue("Total"));
        }

        public static async Task<IPagedList<TQ>> ToPagedListAsync<T, TQ>(this IFindFluent<T, TQ> query, int page = 1, int pageSize = 0)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            var totalCount = query.Count();

            var pagingConfig = new PagingConfig(page, pageSize);
            var skipCount = ValidatePagePropertiesAndGetSkipCount(pagingConfig);

            var data = await query
                .Skip(skipCount)
                .Limit(pagingConfig.PageSize)
                .ToListAsync();

            if (skipCount > 0 && data.Count == 0)
            {
                // Requested page has no records, just return the first page
                pagingConfig.Page = 1;
                data = await query
                    .Limit(pagingConfig.PageSize)
                    .ToListAsync();
            }

            return new PagedList<TQ>(data, pagingConfig.Page, pagingConfig.PageSize, totalCount);
        }

        public static IPagedList<TQ> ToPagedList<T, TQ>(this IFindFluent<T, TQ> query, int page = 1, int pageSize = 0, SortDefinition<T> sort = null)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            var pagingConfig = new PagingConfig(page, pageSize);
            var skipCount = ValidatePagePropertiesAndGetSkipCount(pagingConfig);
            var totalCount = query.Count();
            var data = query
                .Skip(skipCount)
                .Limit(pagingConfig.PageSize)
                .ToList();

            if (skipCount > 0 && data.Count == 0)
            {
                // Requested page has no records, just return the first page
                pagingConfig.Page = 1;
                data = query
                    .Limit(pagingConfig.PageSize)
                    .ToList();
            }

            return new PagedList<TQ>(data, pagingConfig.Page, pagingConfig.PageSize, totalCount);
        }

        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> query, int page = 1, int pageSize = 0)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            var pagingConfig = new PagingConfig(page, pageSize);
            var skipCount = ValidatePagePropertiesAndGetSkipCount(pagingConfig);

            var data = query
                .Skip(skipCount)
                .Take(pagingConfig.PageSize)
                .ToList();

            if (skipCount > 0 && data.Count == 0)
            {
                // Requested page has no records, just return the first page
                pagingConfig.Page = 1;
                data = query
                    .Take(pagingConfig.PageSize)
                    .ToList();
            }

            return new PagedList<T>(data, pagingConfig.Page, pagingConfig.PageSize, query.Count());
        }

    }
}
