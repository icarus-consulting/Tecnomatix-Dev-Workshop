using Yaapii.Atoms;
using Yaapii.Atoms.Text;

namespace InspectorGadget.Entity.Location
{
    /// <summary>
    /// An envelope for <see cref="ILocation"/>
    /// </summary>
    public abstract class LocationEnvelope : ILocation
    {
        private readonly IText id;
        private readonly IText name;
        private readonly IProps props;

        /// <summary>
        /// An envelope for <see cref="ILocation"/>
        /// </summary>
        public LocationEnvelope(string id, string name, IProps props) : this(
            () => id,
            () => name,
            props
        )
        { }

        /// <summary>
        /// An envelope for <see cref="ILocation"/>
        /// </summary>
        public LocationEnvelope(Func<string> id, Func<string> name, IProps props) : this(
            new TextOf(id),
            new TextOf(name),
            props
        )
        { }

        /// <summary>
        /// An envelope for <see cref="ILocation"/>
        /// </summary>
        public LocationEnvelope(IText id, IText name, IProps props)
        {
            this.id = id;
            this.name = name;
            this.props = props;
        }

        public string Id()
        {
            return id.AsString();
        }

        public string Name()
        {
            return name.AsString();
        }

        public IProps Props()
        {
            return props;
        }
    }
}
