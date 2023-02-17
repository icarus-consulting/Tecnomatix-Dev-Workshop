using Tecnomatix.Engineering;
using Yaapii.Atoms;
using Yaapii.Atoms.Scalar;

namespace TmxSmarts.Robot
{
    public class TuRobot : ScalarEnvelope<TxRobot>
    {
        public TuRobot(ITxRoboticLocationOperation location): this(
            ScalarOf.New(() => 
                new TsConvert<TxRobot>(location.ParentRoboticOperation.Robot).Value().ProcessModelId
            )
        )
        { }
        public TuRobot(string externalId) : this(
          ScalarOf.New(() => new TxProcessModelId(externalId))
        )
        { }

        public TuRobot(IScalar<TxProcessModelId> externalId) : base(() =>
           new EIDGrab<TxRobot>(externalId).Value()
        )
        { }

        public TuRobot(ITxRoboticOrderedCompoundOperation program) : base(() =>
           new TsConvert<TxRobot>(program.Robot).Value()
        )
        { }

        public TuRobot(IScalar<ITxRoboticOrderedCompoundOperation> program) : base(() =>
            new TsConvert<TxRobot>(program.Value().Robot).Value()
        )
        { }
    }
}
