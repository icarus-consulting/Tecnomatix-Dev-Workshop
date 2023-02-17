using BriX;
using Tecnomatix.Engineering;
using TmxSmarts;
using TmxSmarts.Location;
using TmxSmarts.Robot;
using Yaapii.Atoms;
using Yaapii.Atoms.Collection;
using Yaapii.Atoms.Scalar;

namespace InspectorGadget.Tmx.Plugin.Brix
{
    /// <summary>
    /// A program represented as <see cref="IBrix"/>
    /// </summary>
    public sealed class BxProgram : BrixEnvelope
    {
        /// <summary>
        /// A program represented as <see cref="IBrix"/>
        /// </summary>
        public BxProgram(ITxRoboticOrderedCompoundOperation program) : this(
          ScalarOf.New(program)  
        )
        { }
        /// <summary>
        /// A program represented as <see cref="IBrix"/>
        /// </summary>
        public BxProgram(IScalar<ITxRoboticOrderedCompoundOperation> program) : base(() =>
        {
            var prog = program.Value();
            return
                 new BxBlock(
                     "program",
                     new BxChain(
                        new BxMap(
                            "name", prog.Name,
                            "externalId", new TsConvert<ITxProcessModelObject>(prog).Value().ProcessModelId.ExternalId
                        ),
                        new BxRobot(new TuRobot(program)),
                        new BxBlockArray(
                            "locations",
                            "location",
                            Mapped.New(
                                location => new BxLocation(new TuRoboticLocationOperation(location)),
                                prog.GetAllDescendants(new TxTypeFilter(typeof(ITxRoboticLocationOperation)))
                            )

                        )
                    )
                );
        })
        { }
    }
}
