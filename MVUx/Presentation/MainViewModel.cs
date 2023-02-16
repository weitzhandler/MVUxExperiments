using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MVUx.Data;
using MVUx.Models;
using Uno.Extensions;
using Uno.Extensions.Reactive;
using Uno.Extensions.Reactive.Commands;

namespace MVUx.Presentation;

public partial class MainViewModel
{
    public MainViewModel(IDataStore dataStore)
    {
        DataStore = dataStore;
    }

    public IDataStore DataStore { get; }

    public IListFeed<Person> People =>
        ListFeed.Async(DataStore.GetPeople);

    public IListFeed<Person> PeoplePaginated =>
        ListFeed.AsyncPaginated(DataStore.GetPeople);

}
