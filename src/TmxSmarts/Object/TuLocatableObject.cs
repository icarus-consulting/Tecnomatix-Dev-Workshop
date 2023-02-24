using Tecnomatix.Engineering;
using Yaapii.Atoms;
using Yaapii.Atoms.Scalar;

namespace TmxSmarts.Object
{
    public sealed class TuLocatableObject : ScalarEnvelope<ITxLocatableObject>
    {

        public TuLocatableObject(IScalar<TxRobot> robot) : base(
            () =>
                new TsConvert<ITxLocatableObject>(
                    new TsConvert<ITxObject>(
                        robot.Value()
                    )
                ).Value()
        )
        { }

        public TuLocatableObject(TxRobot robot) : this(new TsConvert<ITxLocatableObject>(robot))
        {

        }

        public TuLocatableObject(ITxObject tuneObject) :this(
           new TsConvert<ITxLocatableObject>(tuneObject)  
        )
        { }

        public TuLocatableObject(string externalId) :this(
            new EIDGrab<ITxLocatableObject>(externalId)
        )
        { }

        public TuLocatableObject(IScalar<ITxLocatableObject> locatableObject) : base(
            locatableObject
        )
        { }
    }
}
