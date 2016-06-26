using Managed.Search;
using Xunit;

namespace SecretOrange.Search.Tests
{
    public class LuceneCompilerTests
    {
        [Fact]
        public void SimpleANDField()
        {
            var luceneString = Query.Field("firstname", "spongebob").And().Field("lastname", "squarepants")
                                .ToQuery()
                                .ToLuceneString();

            // OUTPUT: (firstname:"spongebob" AND lastname:"squarepants")
            Assert.Equal(luceneString, @"(firstname:""spongebob"" AND lastname:""squarepants"")");
        }

        [Fact]
        public void GroupedAND()
        {
            var name = Query.Field("firstname", "spongebob").And().Field("lastname", "squarepants");

            var age = Query.Field("age", 30).Or().Field("age", 31);

            var luceneString = name.And(age).ToQuery().ToLuceneString();

            // OUTPUT: (firstname:"spongebob" AND lastname:"squarepants" AND (age:30 OR age:31))
            Assert.Equal(luceneString, @"(firstname:""spongebob"" AND lastname:""squarepants"" AND (age:30 OR age:31))");
        }

        [Fact]
        public void GroupedANDWithRange()
        {
            var name = Query.Field("firstname", "spongebob").And().Field("lastname", "squarepants");

            var age = Query.Range("age", 30, 40);

            var luceneString = name.And(age).ToQuery().ToLuceneString();

            // OUTPUT: (firstname:"spongebob" AND lastname:"squarepants" AND (age:[30 TO 40]))
            Assert.Equal(luceneString, @"(firstname:""spongebob"" AND lastname:""squarepants"" AND (age:[30 TO 40]))");
        }
    }
}