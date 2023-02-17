using Yaapii.Atoms;
using Yaapii.Atoms.Scalar;

namespace InspectorGadget.Entity.Robot
{
    public abstract class RobotEnvelope : IRobot
    {
        private readonly IScalar<string> id;
        private readonly IScalar<string> name;
        private readonly IScalar<IProps> props;
        public RobotEnvelope(string id, string name, IProps props) : this(
          ScalarOf.New(id),
          ScalarOf.New(name),
          ScalarOf.New(props)
        )
        { }
        public RobotEnvelope(IScalar<string> id, IScalar<string> name, IScalar<IProps> props)
        {
            this.id = id;
            this.name = name;
            this.props = props;
        }
        public string Id()
        {
            return id.Value();
        }

        public string Name()
        {
            return name.Value();
        }

        public IProps Props()
        {
            return props.Value();
        }
    }
}
