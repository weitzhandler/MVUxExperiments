using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MVUx.Data;
using MVUx.Models;
using Uno.Extensions;
using Uno.Extensions.Reactive;

namespace MVUx.Presentation;

public partial class ListStateViewModel
{
    private readonly IDataStore dataStore;

    public ListStateViewModel(IDataStore dataStore)
    {
        this.dataStore = dataStore;
    }

    public async ValueTask LoadMore(CancellationToken ct)
    {
        var nextPeople = await dataStore.GetPeopleAsync(ct);

        await People.UpdateData(existing =>
        {
            var existingData = existing.SomeOrDefault();
            var newPeople = existingData.Concat(nextPeople);

            return (Option<IImmutableList<Person>>)newPeople.ToImmutableList();
        },
        ct);
    }

    public async ValueTask Sort(SortOption sort, CancellationToken ct)
    {
        //await People.UpdateData(existing =>
        //{
        //
        //});
    }

    public IListState<Person> People =>
        ListState<Person>.Async(this, dataStore.GetPeopleAsync);

}

public enum SortOption
{
    First,
    Last,
}