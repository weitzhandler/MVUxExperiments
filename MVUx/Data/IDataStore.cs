using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using MVUx.Models;
using Uno.Extensions.Reactive;

namespace MVUx.Data;

public interface IDataStore
{
    ValueTask<IImmutableList<Person>> GetPeople(
        //PageRequest page,
        CancellationToken ct);
}
