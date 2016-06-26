using Managed.Search.Operations;
using System.Collections.Generic;

namespace Managed.Search
{
    public class Clause : List<BooleanOperation>
    {
        public BooleanOperator CurrentOperator = BooleanOperator.And;
    }
}