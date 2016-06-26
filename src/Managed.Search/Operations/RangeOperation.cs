using Managed.Search.Operations;

namespace Managed.Search.Operations
{
    public class RangeOperation : BooleanOperation
    {
        public RangeOperation(BooleanOperator booleanOperator, string field, object from, object to)
        {
            Field = field;
            From = from;
            To = to;
            Operator = booleanOperator;
        }

        public string Field { get; set; }

        public object From { get; set; }

        public object To { get; set; }
    }
}

namespace Managed.Search
{
    public static partial class ClauseExtensions
    {
        public static Clause Range(this Clause clause, string field, object from, object to)
        {
            clause.Add(new RangeOperation(clause.CurrentOperator, field, from, to));
            return clause;
        }
    }

    public partial class Query
    {
        public static Clause Range(string field, object from, object to)
        {
            return new Clause().Range(field, from, to);
        }
    }
}