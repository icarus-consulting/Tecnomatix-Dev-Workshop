using BriX;
using Tecnomatix.Engineering;
using TmxSmarts;
using Yaapii.Atoms;

namespace InspectorGadget.Tmx.Plugin.Brix
{
    /// <summary>
    /// A location represented as <see cref="IBrix"/>
    /// </summary>
    public sealed class BxLocation : BrixEnvelope
    {
        /// <summary>
        /// A location represented as <see cref="IBrix"/>
        /// </summary>
        public BxLocation(IScalar<ITxRoboticLocationOperation> location) : base(() =>
        {
            var loc = location.Value();
            var position = new TsConvert<ITxLocatableObject>(loc).Value().AbsoluteLocation;
            return
                new BxBlock(
                    "location",
                    new BxMap(
                        "name", loc.Name,
                        "externalId", new TsConvert<ITxProcessModelObject>(loc).Value().ProcessModelId.ExternalId,
                        "transformation", $"{position.Translation} {position.RotationRPY_XYZ}",
                        "motionType", ((TxMotionType)(loc.GetParameter("RRS_MOTION_TYPE") as TxRoboticIntParam).Value).ToString()
                    )
                );
        })
        { }
    }
}
