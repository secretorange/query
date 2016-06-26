using Managed.Search;
using Managed.Search.Operations;
using System;

namespace SecretOrange.Search.Compilers.Lucene
{
    public class LuceneQueryCompiler
    {
        public static string Compile(Query query)
        {
            return new LuceneQueryCompiler().CompileQuery(query);
        }

        public string CompileQuery(Query query)
        {
            return CompileClause(query.Clause);
        }

        private string CompileClause(Clause clause)
        {
            var query = "(";

            for (var i = 0; i < clause.Count; i++)
            {
                var operation = clause[i];

                // Check it's not an empty clause, if so just ignore it...
                if (operation is ClauseOperation && ((ClauseOperation)operation).Clause.Count == 0)
                    continue;

                if (i > 0)
                    query += GetOperandString(operation.Operator);

                query += Compile(operation);
            }

            query += ")";

            return query;
        }

        private string Compile(BooleanOperation booleanOperation)
        {
            var query = String.Empty;

            var type = booleanOperation.GetType();

            if (type == typeof(ClauseOperation))
            {
                query = CompileClause(((ClauseOperation)booleanOperation).Clause);
            }
            else if (type == typeof(FieldOperation))
            {
                query = Compile((FieldOperation)booleanOperation);
            }
            else if (type == typeof(RangeOperation))
            {
                query = Compile((RangeOperation)booleanOperation);
            }

            return query;
        }

        private string Compile(FieldOperation fieldOperation)
        {
            string value = GetValue(fieldOperation.Value);

            return String.Format("{0}:{1}", fieldOperation.Field, value);
        }

        private string Compile(RangeOperation rangeOperation)
        {
            var from = GetValue(rangeOperation.From);
            var to = GetValue(rangeOperation.To);

            return String.Format("{0}:[{1} TO {2}]", rangeOperation.Field, from, to);
        }

        // Safer to always quote strings
        private string GetValue(object value)
        {
            if (value is string)
                return $"\"{value}\"";
            else
                return value.ToString();
        }

        private string GetOperandString(BooleanOperator booleanOperator)
        {
            switch (booleanOperator)
            {
                case BooleanOperator.And:
                    return " AND ";
                case BooleanOperator.Or:
                    return " OR ";
                case BooleanOperator.Not:
                    return " NOT ";
                case BooleanOperator.Unknown:
                    return " UNKNOWN "; //TODO - WE NEED DEFAULT OPERATOR...
                default:
                    return String.Empty;
            }
        }
    }
}