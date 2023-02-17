namespace InspectorGadget.Entity.Location
{
    /// <summary>
    /// A simple <see cref="ILocation"/>
    /// </summary>
    public sealed class SimpleLocation : LocationEnvelope
    {
        /// <summary>
        /// A simple <see cref="ILocation"/>
        /// </summary>
        public SimpleLocation(string id, string name, IProps props) : base(
            id,
            name,
            props
        )
        { }
    }
}
