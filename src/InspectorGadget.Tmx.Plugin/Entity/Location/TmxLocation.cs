using InspectorGadget.Entity.Location;
using InspectorGadget.Entity.Props;
using Tecnomatix.Engineering;
using TmxSmarts;
using Yaapii.Atoms;
using Yaapii.Atoms.Map;
using Yaapii.Atoms.Scalar;

namespace InspectorGadget.Tmx.Plugin.Entity.Location
{
    /// <summary>
    /// A <see cref="InspectorGadget.Core.Model.ILocation"/> from <see cref="ITxRoboticLocationOperation"/>
    /// </summary>
    public sealed class TmxLocation : LocationEnvelope
    {
        /// <summary>
        /// A <see cref="InspectorGadget.Core.Model.ILocation"/> from <see cref="ITxRoboticLocationOperation"/>
        /// </summary>
        public TmxLocation(ITxRoboticLocationOperation location) : this(
          ScalarOf.New(location)  
        )
        { }

        /// <summary>
        /// A <see cref="InspectorGadget.Core.Model.ILocation"/> from <see cref="ITxRoboticLocationOperation"/>
        /// </summary>
        public TmxLocation(IScalar<ITxRoboticLocationOperation> location) : base(
          () => new TsConvert<ITxProcessModelObject>(location.Value()).Value().ProcessModelId.ExternalId,
          () => location.Value().Name,
          new SimpleProps(() =>
          {
              var loc = location.Value();
              var position = new TsConvert<ITxLocatableObject>(loc).Value().AbsoluteLocation;
              return
                MapOf.New(
                    KvpOf.New("transformation", $"{position.Translation.ToString()} {position.RotationRPY_XYZ}"),
                    KvpOf.New("motionType", ((TxMotionType)(loc.GetParameter("RRS_MOTION_TYPE") as TxRoboticIntParam).Value).ToString())
                );
          })
        )
        { }
    }
}
