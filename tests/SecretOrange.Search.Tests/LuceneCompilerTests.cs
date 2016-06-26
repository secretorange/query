using Managed.Search;
using Xunit;

namespace SecretOrange.Search.Tests
{
    public class LuceneCompilerTests
    {
        [Fact]
        public void GroupedAND()
        {
            var name = Query.Field("firstname", "spongebob").And().Field("lastname", "squarepants");

            var age = Query.Field("age", 30).Or().Field("age", 31);

            var luceneString = name.And(age).ToQuery().ToLuceneString();

            Assert.Equal(luceneString, @"(firstname:""spongebob"" AND lastname:""squarepants"" AND (age:30 OR age:31))");
        }

        public void GroupedANDWithRange()
        {
            var name = Query.Field("firstname", "spongebob").And().Field("lastname", "squarepants");

            var age = Query.Range("age", 30, 40);

            var luceneString = name.And(age).ToQuery().ToLuceneString();

            Assert.Equal(luceneString, @"(firstname:""spongebob"" AND lastname:""squarepants"" AND (age:[30 TO 40]))");
        }

        [Fact]
        public void SimpleANDField()
        {
            var luceneString = Query.Field("firstname", "spongebob").And().Field("lastname", "squarepants")
                                .ToQuery()
                                .ToLuceneString();

            Assert.Equal(luceneString, @"(firstname:""spongebob"" AND lastname:""squarepants"")");
        }
    }
}