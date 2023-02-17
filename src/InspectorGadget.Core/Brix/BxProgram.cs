using BriX;
using InspectorGadget.Core.Model;
using InspectorGadget.Entity;
using Yaapii.Atoms;
using Yaapii.Atoms.Collection;
using Yaapii.Atoms.Scalar;

namespace InspectorGadget.Core.Brix
{
    /// <summary>
    /// A program represented as <see cref="IBrix"/>
    /// </summary>
    public sealed class BxProgram : BrixEnvelope
    {
        /// <summary>
        /// A program represented as <see cref="IBrix"/>
        /// </summary>
        public BxProgram(IProgram program) : base(() =>
        {
            return
                 new BxBlock(
                     "program",
                     new BxChain(
                        new BxMap(
                            "name", program.Name(),
                            "externalId", program.Id()
                        ),
                        new BxRobot(program.Robot()),
                        new BxBlockArray(
                            "locations",
                            "location",
                            Mapped.New(
                                location => new BxLocation(location),
                                program.Locations()
                            )

                        )
                    )
                );
        })
        { }
    }
}
