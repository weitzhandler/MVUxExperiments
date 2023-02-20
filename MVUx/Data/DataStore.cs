using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Uno.Extensions.Reactive;
using Person = MVUx.Models.Person;

namespace MVUx.Data;

public class DataStore : IDataStore
{
    public async ValueTask<IImmutableList<Person>> GetPeopleAsync(
        CancellationToken ct = default)
    {
        await Task.Delay(1000, ct);

        var data =
            await GetUnlimitedPeople()
            .Take(5)
            .ToListAsync();

        return data.ToImmutableList();
    }

    public async ValueTask<IImmutableList<Person>> GetPeopleAsync(
    PageRequest page,
    CancellationToken ct = default)
    {
        await Task.Delay(1000, ct);

        var desiredSize = (int)page.DesiredSize;

        var data =
            await GetUnlimitedPeople()
            //.Skip((int)page.Index * desiredSize)
            .Take(desiredSize)
            .ToListAsync();

        return data.ToImmutableList();
    }

    private async IAsyncEnumerable<Person> GetUnlimitedPeople([EnumeratorCancellation] CancellationToken ct = default)
    {

        var faker =
            new Faker<Person>()
            .CustomInstantiator(faker => new Person(faker.Name.FirstName(), faker.Name.LastName()));

        while (!ct.IsCancellationRequested)
        {
            yield return faker.Generate();
        }

        await Task.CompletedTask;
    }
}