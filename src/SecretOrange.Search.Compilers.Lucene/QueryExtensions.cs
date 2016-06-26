using SecretOrange.Search.Compilers.Lucene;

namespace Managed.Search
{
    public static class QueryExtensions
    {
        public static string ToLuceneString(this Query query)
        {
            return LuceneQueryCompiler.Compile(query);
        }
    }
}