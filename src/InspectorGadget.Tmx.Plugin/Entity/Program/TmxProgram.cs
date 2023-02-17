using InspectorGadget.Entity;
using InspectorGadget.Entity.Program;
using InspectorGadget.Entity.Props;
using InspectorGadget.Tmx.Plugin.Entity.Location;
using InspectorGadget.Tmx.Plugin.Entity.Robot;
using Tecnomatix.Engineering;
using TmxSmarts;
using TmxSmarts.Location;
using TmxSmarts.Robot;
using Yaapii.Atoms;
using Yaapii.Atoms.List;
using Yaapii.Atoms.Map;
using Yaapii.Atoms.Scalar;

namespace InspectorGadget.Tmx.Plugin.Entity.Program
{
    /// <summary>
    /// A <see cref="InspectorGadget.Core.Model.IProgram"/> from <see cref="ITxRoboticOrderedCompoundOperation"/>
    /// </summary>
    public sealed class TmxProgram : ProgramEnvelope
    {
        public TmxProgram(ITxRoboticOrderedCompoundOperation program) :this(
          ScalarOf.New(program)  
        )
        { }

        /// <summary>
        /// A <see cref="InspectorGadget.Core.Model.IProgram"/> from <see cref="ITxRoboticOrderedCompoundOperation"/>
        /// </summary>
        public TmxProgram(IScalar<ITxRoboticOrderedCompoundOperation> program) : base(
            () => new TsConvert<ITxProcessModelObject>(program.Value()).Value().ProcessModelId.ExternalId,
            () => program.Value().Name,
            new SimpleProps(() => new MapOf<string>()),
            new TmxRobot(new TuRobot(program)),
            new ListOf<ILocation>(
                Yaapii.Atoms.Enumerable.Mapped.New(
                    location => new TmxLocation(new TuRoboticLocationOperation(location)),
                    program.Value().GetAllDescendants(new TxTypeFilter(typeof(ITxRoboticLocationOperation)))
                )
            )
        )
        { }
    }
}
