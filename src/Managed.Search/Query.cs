using System.Collections.Generic;

namespace Managed.Search
{
    public partial class Query
    {
        public int PageSize { get; set; } = 10;

        public int Page { get; set; }

        public Clause Clause { get; set; }

        // Support multiple OrderBy statements. i.e. OrderBy(this).Then(that);
        public IList<OrderBy> OrderBys { get; set; }
 
        public Query(Clause clause)
        {
            OrderBys = new List<OrderBy>();
            Clause = clause;
        }

        public Query(Clause clause, int page, int pageSize)
            : this(clause)
        {
            Page = page;
            PageSize = pageSize;
        }

        public Query OrderByDescending(string field)
        {
            OrderBys.Add(new OrderBy() { Direction = OrderByDirection.Descending, Field = field });

            return this;
        }

        public Query OrderByAscending(string field)
        {
            OrderBys.Add(new OrderBy() { Direction = OrderByDirection.Ascending, Field = field });

            return this;
        }
    }
}