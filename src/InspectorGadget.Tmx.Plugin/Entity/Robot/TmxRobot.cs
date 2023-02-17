using InspectorGadget.Entity.Props;
using InspectorGadget.Entity.Robot;
using Tecnomatix.Engineering;
using TmxSmarts;
using Yaapii.Atoms;
using Yaapii.Atoms.Scalar;

namespace InspectorGadget.Tmx.Plugin.Entity.Robot
{
    /// <summary>
    /// A <see cref="InspectorGadget.Core.Model.IRobot"/> from <see cref="TxRobot"/>
    /// </summary>
    public sealed class TmxRobot : RobotEnvelope
    {
        /// <summary>
        /// A <see cref="InspectorGadget.Core.Model.IRobot"/> from <see cref="TxRobot"/>
        /// </summary>
        public TmxRobot(TxRobot robot) : this(
            ScalarOf.New(robot)
        )
        { }

        /// <summary>
        /// A <see cref="InspectorGadget.Core.Model.IRobot"/> from <see cref="TxRobot"/>
        /// </summary>
        public TmxRobot(IScalar<TxRobot> robot) : base(
          ScalarOf.New(() => new TsConvert<ITxProcessModelObject>(robot.Value()).Value().ProcessModelId.ExternalId),
          ScalarOf.New(() => robot.Value().Name),
          ScalarOf.New(() =>
                new SimpleProps()
                    .Refined("controller", robot.Value().Controller.Name)
          )
        )
        { }
    }
}
