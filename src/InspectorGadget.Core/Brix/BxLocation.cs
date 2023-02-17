using BriX;
using InspectorGadget.Entity;

namespace InspectorGadget.Core.Brix
{
    /// <summary>
    /// A location represented as <see cref="IBrix"/>
    /// </summary>
    public sealed class BxLocation : BrixEnvelope
    {
        /// <summary>
        /// A location represented as <see cref="IBrix"/>
        /// </summary>
        public BxLocation(ILocation location) : base(() =>
        {
            return
                new BxBlock(
                    "location",
                    new BxMap(
                        "name", location.Name(),
                        "externalId", location.Id(),
                        "transformation", location.Props().Value("transformation"),
                        "motionType", location.Props().Value("motionType", () => "unknown")
                    )
                );
        })
        { }
    }
}
