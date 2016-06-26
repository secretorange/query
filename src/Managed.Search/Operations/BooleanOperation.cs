using Managed.Search.Operations;

namespace Managed.Search.Operations
{
    public abstract class BooleanOperation
    {
        public BooleanOperator Operator { get; set; }
    }
}