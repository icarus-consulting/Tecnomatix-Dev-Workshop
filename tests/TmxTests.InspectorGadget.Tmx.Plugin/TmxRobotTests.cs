extern alias XunitExecutionTecnomatix;

using InspectorGadget.Tmx.Plugin.Entity.Robot;
using TmxSmarts.Robot;
using Xunit;

namespace TmxTests.InspectorGadget.Tmx.Plugin
{
    public class TmxRobotTests
    {
        [XunitExecutionTecnomatix.Xunit.TmxFact]
        public void HasId()
        {
            var robotId = "PP-0b3ceaec-8360-488f-b939-2c84f9986879";
            var robot = new TmxRobot(new TuRobot(robotId));
            Assert.Equal(robotId, robot.Id());
        }

        [XunitExecutionTecnomatix.Xunit.TmxFact]
        public void HasName()
        {
            var robotId = "PP-0b3ceaec-8360-488f-b939-2c84f9986879";
            var robot = new TmxRobot(new TuRobot(robotId));
            Assert.Equal("1540211R1", robot.Name());
        }
    }
}