using BriX;
using Tecnomatix.Engineering;
using Yaapii.Atoms;

namespace InspectorGadget.Tmx.Plugin.Brix
{
    /// <summary>
    /// A robot represented as <see cref="IBrix"/>
    /// </summary>
    public sealed class BxRobot : BrixEnvelope
    {
        /// <summary>
        /// A robot represented as <see cref="IBrix"/>
        /// </summary>
        public BxRobot(IScalar<TxRobot> robot) : base(() =>
        {
            var rob = robot.Value();
            return
                new BxBlock(
                    "robot",
                    new BxMap(
                        "name",rob.Name,
                        "externalId", rob.ProcessModelId.ExternalId,
                        "controller", rob.Controller.Name
                    )
                );
        })
        { }
    }
}
