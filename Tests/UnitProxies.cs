using Proxies;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class UnitProxies
    {
        public UnitProxies()
        {


        }

        [Fact]
        public void getSAPNWRFCresults()
        {
            SAPNWRFC.Result rfcoutput = SAPNWRFC.execute("host", "user", "password", "client");

            Assert.True(rfcoutput!= null && rfcoutput.codes.Length > 0);
        }

    }
}
