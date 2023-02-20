using MVUx.Data;
using MVUx.Models;
using Uno.Extensions.Reactive;
using Xunit;

namespace TestPlayground
{
    public class DataStoreTests
    {
        [Fact]
        public async Task PaginatedPeopleTest()
        {
            // arrange
            var store = new DataStore();
            var result = new List<Person>();

            var page = new PageRequest
            {
                DesiredSize = 2,
                Index = 0
            };

            var pageCount = 10;

            // act
            for (int i = 0; i < pageCount; i++)
            {
                var people = await store.GetPeopleAsync(page);
                result.AddRange(people);

                page =
                    page with
                    {
                        CurrentCount = page.CurrentCount + 1
                    };
            }

            // assert
            Assert.Equal(expected: pageCount * page.DesiredSize, actual: result.Count);
            Assert.All(result, person => Assert.NotEmpty(person.ToString()));
        }

        [Fact]
        public async Task GetPeopleTest()
        {
            // arrange
            var store = new DataStore();

            // act
            var result = await store.GetPeopleAsync();

            // assert
            Assert.Equal(expected: 20, actual: result.Count);
            Assert.All(result, person => Assert.NotEmpty(person.ToString()));
        }
    }
}