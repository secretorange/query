using Managed.Search.Operations;
using System;

namespace Managed.Search.Operations
{
    public class TypeOperation : BooleanOperation
    {
        public TypeOperation(BooleanOperator booleanOperator, Type[] types)
        {
            Operator = booleanOperator;
            Types = types;
        }

        public Type[] Types { get; set; }
    }
}

namespace Managed.Search
{
    public static partial class ClauseExtensions
    {
        public static Clause Types(this Clause clause, params Type[] types)
        {
            clause.Add(new TypeOperation(clause.CurrentOperator, types));
            return clause;
        }
    }

    public partial class Query
    {
        public static Clause Types(params Type[] types)
        {
            return new Clause().Types(types);
        }
    }
}