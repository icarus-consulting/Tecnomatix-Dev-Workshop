using BriX;
using InspectorGadget.Core.Model;
using InspectorGadget.Entity;

namespace InspectorGadget.Core.Brix
{
    /// <summary>
    /// A robot represented as <see cref="IBrix"/>
    /// </summary>
    public sealed class BxRobot : BrixEnvelope
    {
        /// <summary>
        /// A robot represented as <see cref="IBrix"/>
        /// </summary>
        public BxRobot(IRobot robot) : base(() =>
        {
            return
                new BxBlock(
                    "robot",
                    new BxMap(
                        "name", robot.Name(),
                        "externalId", robot.Id(),
                        "controller", robot.Props().Value("controller",() => "unknown")
                    )
                );
        })
        { }
    }
}
