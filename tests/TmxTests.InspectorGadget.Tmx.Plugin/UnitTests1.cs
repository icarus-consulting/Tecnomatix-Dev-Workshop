extern alias XunitExecutionTecnomatix;
using Xunit;

namespace TmxTests.InspectorGadget.Tmx.Plugin
{
    public class UnitTests1
    {
        [XunitExecutionTecnomatix.Xunit.TmxFact]
        public void Test1()
        {
            Assert.True(true);
        }
    }
}