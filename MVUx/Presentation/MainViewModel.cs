using MVUx.Data;
using MVUx.Models;
using Uno.Extensions.Reactive;

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

}
