using Managed.Search.Operations;

namespace Managed.Search.Operations
{
    public class ClauseOperation : BooleanOperation
    {
        public ClauseOperation(BooleanOperator booleanOperator, Clause clause)
        {
            Clause = clause;
            Operator = booleanOperator;
        }

        public Clause Clause { get; set; }
    }
}

namespace Managed.Search
{
    public static partial class ClauseExtensions
    {
        public static Clause And(this Clause clause, Clause innerClause)
        {
            AddGroupedClause(clause.And(), innerClause);
            return clause;
        }

        public static Clause Or(this Clause clause, Clause innerClause)
        {
            AddGroupedClause(clause.Or(), innerClause);
            return clause;
        }

        public static Clause Not(this Clause clause, Clause innerClause)
        {
            AddGroupedClause(clause.Not(), innerClause);
            return clause;
        }

        private static void AddGroupedClause(this Clause clause, Clause groupedClause)
        {
            clause.Add(new ClauseOperation(clause.CurrentOperator, groupedClause));
        }
    }
}