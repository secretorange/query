namespace Managed.Search
{
    public static partial class ClauseExtensions
    {
        public static Clause And(this Clause clause)
        {
            clause.CurrentOperator = BooleanOperator.And;
            return clause;
        }

        public static Clause Or(this Clause clause)
        {
            clause.CurrentOperator = BooleanOperator.Or;
            return clause;
        }

        public static Clause Not(this Clause clause)
        {
            clause.CurrentOperator = BooleanOperator.Not;
            return clause;
        }

        public static Query ToQuery(this Clause clause)
        {
            return new Query(clause);
        }
    }
}