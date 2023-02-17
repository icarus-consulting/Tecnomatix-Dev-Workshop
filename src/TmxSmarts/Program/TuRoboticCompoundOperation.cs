using Tecnomatix.Engineering;
using Yaapii.Atoms;
using Yaapii.Atoms.Scalar;

namespace TmxSmarts.Program
{
    /// <summary>
    /// a <see cref="ITxRoboticOrderedCompoundOperation"/>
    /// </summary>
    public sealed class TuRoboticCompoundOperation : ScalarEnvelope<ITxRoboticOrderedCompoundOperation>
    {
        /// <summary>
        /// a <see cref="ITxRoboticOrderedCompoundOperation"/>
        /// </summary>
        public TuRoboticCompoundOperation(ITxRoboticLocationOperation location) : base(() => 
            location.ParentRoboticOperation
        )
        { }

        /// <summary>
        /// a <see cref="ITxRoboticOrderedCompoundOperation"/>
        /// </summary>
        public TuRoboticCompoundOperation(IScalar<ITxRoboticLocationOperation> location) : base(() =>
            location.Value().ParentRoboticOperation
        )
        { }


        /// <summary>
        /// a <see cref="ITxRoboticOrderedCompoundOperation"/>
        /// </summary>
        public TuRoboticCompoundOperation(string externalId) : base(() =>
            new EIDGrab<ITxRoboticOrderedCompoundOperation>(externalId).Value()
        )
        { }

        /// <summary>
        /// a <see cref="ITxRoboticOrderedCompoundOperation"/>
        /// </summary>
        public TuRoboticCompoundOperation(TxProcessModelId externalId) : base(() =>
            new EIDGrab<ITxRoboticOrderedCompoundOperation>(externalId).Value()
        )
        { }

        /// <summary>
        /// a <see cref="ITxRoboticOrderedCompoundOperation"/>
        /// </summary>
        public TuRoboticCompoundOperation(IScalar<TxProcessModelId> externalId) : base(() => 
            new EIDGrab<ITxRoboticOrderedCompoundOperation>(externalId).Value()
        )
        { }
    }
}
