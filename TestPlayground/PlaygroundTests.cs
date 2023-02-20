using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Extensions.Reactive;

namespace TestPlayground
{

    public class PlaygroundTests
    {

        IState<int> Counter => State<int>.Value(this, () => 0);

        [Fact]
        public async Task StateUpdateTest()
        {

            await UpdateCounter();

            await UpdateCounter();
            
            await UpdateCounter();

        }

        async Task UpdateCounter()
        {
            CancellationToken token = default;
            await Counter.Update(current => current + 1, token);

        }
    }
}
