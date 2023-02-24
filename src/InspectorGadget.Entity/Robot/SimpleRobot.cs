using InspectorGadget.Entity.Props;
using System.Collections.Generic;

namespace InspectorGadget.Entity.Robot
{
    public sealed class SimpleRobot : RobotEnvelope
    {
        public SimpleRobot(string id, string name, IDictionary<string, string> props) : this(
            id,
            name,
            new SimpleProps(props)
        )
        { }

        public SimpleRobot(string id, string name, IProps props) : base(id, name, props)
        { }
    }
}
