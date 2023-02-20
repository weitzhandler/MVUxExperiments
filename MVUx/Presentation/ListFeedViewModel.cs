using MVUx.Data;
using MVUx.Models;
using Uno.Extensions.Reactive;

namespace MVUx.Presentation;

public partial class ListFeedViewModel
{
    public ListFeedViewModel(IDataStore dataStore)
    {
        DataStore = dataStore;
    }

    public IDataStore DataStore { get; }    

    public IListFeed<Person> People =>
        ListFeed.Async(DataStore.GetPeopleAsync);

    public IListFeed<Person> PeoplePaginated =>
        ListFeed.AsyncPaginated(DataStore.GetPeopleAsync);
}