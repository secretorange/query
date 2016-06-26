using Managed.Search.Operations;

namespace Managed.Search.Operations
{
    public class FieldOperation : BooleanOperation
    {
        public FieldOperation(BooleanOperator booleanOperator, string field, object value)
        {
            Field = field;
            Value = value;
            Operator = booleanOperator;
        }

        public string Field { get; set; }

        public object Value { get; set; }
    }
}

namespace Managed.Search
{
    public static partial class ClauseExtensions
    {
        public static Clause Field(this Clause clause, string field, object value)
        {
            clause.Add(new FieldOperation(clause.CurrentOperator, field, value));
            return clause;
        }
    }

    public partial class Query
    {
        public static Clause Field(string field, object value)
        {
            return new Clause().Field(field, value);
        }
    }
}