extern alias XunitExecutionTecnomatix;

using Google.Protobuf.WellKnownTypes;
using Tecnomatix.Engineering;
using Tecnomatix.Planning;
using TmxSmarts;
using TmxSmarts.Planning;
using Xunit;

namespace TmxTests.TraversalExample.Planning
{
    public class TsChildrenOfTests
    {
        [XunitExecutionTecnomatix.Xunit.TmxFact]
        public void FindsChildren()
        {
            var planningObject = new EIDGrab<TxCompoundResource>("PP-ICARUS-8-2-2016-16-9-40-103700-103729").Value().PlanningRepresentation;
            Assert.Equal(4, new TsChildrenOf(planningObject, "name").Count);
        }
    }
}