using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Uno.Extensions.Reactive;
using Person = MVUx.Models.Person;

namespace MVUx.Data;

public class DataStore : IDataStore
{
    public async ValueTask<IImmutableList<Person>> GetPeople(
        //PageRequest page,
        CancellationToken ct = default)
    {
        await Task.Delay(1000, ct);

        var faker =
            new Faker<Person>()
            .CustomInstantiator(faker => new Person(faker.Name.FirstName(), faker.Name.LastName()));

        return Enumerable
            //.Range((int)page.Index, (int)page.DesiredSize)
            .Range(0,50)
            .Select(i => faker.Generate())
            .ToImmutableList();
    }
}