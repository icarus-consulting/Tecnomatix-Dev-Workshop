using Tecnomatix.Engineering;
using Yaapii.Atoms;
using Yaapii.Atoms.Scalar;

namespace TmxSmarts.Location
{
    public sealed class TuRoboticLocationOperation : ScalarEnvelope<ITxRoboticLocationOperation>
    {
        public TuRoboticLocationOperation(ITxObject txObject) :this(
            new TsConvert<ITxProcessModelObject>(txObject).Value().ProcessModelId
        )
        { }
        
        public TuRoboticLocationOperation(string externalId): this(
            ScalarOf.New(() => new TxProcessModelId(externalId))
        )
        { }

        public TuRoboticLocationOperation(TxProcessModelId externalId) : this(
            ScalarOf.New(() => externalId)
        )
        { }

        public TuRoboticLocationOperation(IScalar<TxProcessModelId> externalId) :base(() => 
            new EIDGrab<ITxRoboticLocationOperation>(externalId).Value()
        )
        { }
    }
}
