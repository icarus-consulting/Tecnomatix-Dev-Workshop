using Yaapii.Atoms;
using Yaapii.Atoms.Text;

namespace InspectorGadget.Entity.Program
{
    /// <summary>
    /// An envelope for <see cref="IProgram"/>
    /// </summary>
    public abstract class ProgramEnvelope : IProgram
    {
        private readonly IText id;
        private readonly IText name;
        private readonly IProps props;
        private readonly IRobot robot;
        private readonly IList<ILocation> locations;

        /// <summary>
        /// An envelope for <see cref="IProgram"/>
        /// </summary>
        public ProgramEnvelope(string id, string name, IProps props, IRobot robot, IList<ILocation> locations) : this(
            () => id,
            () => name,
            props,
            robot,
            locations
        )
        { }

        /// <summary>
        /// An envelope for <see cref="IProgram"/>
        /// </summary>
        public ProgramEnvelope(Func<string> id, Func<string> name, IProps props, IRobot robot, IList<ILocation> locations) : this(
         new TextOf(id),
         new TextOf(name),
         props,
         robot,
         locations
       )
        { }

        /// <summary>
        /// An envelope for <see cref="IProgram"/>
        /// </summary>
        public ProgramEnvelope(IText id, IText name, IProps props, IRobot robot, IList<ILocation> locations)
        {
            this.id = id;
            this.name = name;
            this.props = props;
            this.robot = robot;
            this.locations = locations;
        }

        public string Id()
        {
            return id.AsString();
        }

        public IList<ILocation> Locations()
        {
            return locations;
        }

        public string Name()
        {
            return name.AsString();
        }

        public IProps Props()
        {
            return props;
        }

        public IRobot Robot()
        {
            return robot;
        }
    }
}
