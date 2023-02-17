using Tecnomatix.Engineering;
using Yaapii.Atoms;
using Yaapii.Atoms.Scalar;

namespace TmxSmarts
{
    /// <summary>
    /// Grab a tecnomatix object by external id and cast it into a given type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class EIDGrab<T> : ScalarEnvelope<T> where T : ITxObject
    {
        /// <summary>
        /// Grab a tecnomatix object by external id and cast it into a given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public EIDGrab(string externalId) : this(
            ScalarOf.New(() => new TxProcessModelId(externalId))
        )
        { }

        /// <summary>
        /// Grab a tecnomatix object by external id and cast it into a given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public EIDGrab(TxProcessModelId externalId) : this(
            ScalarOf.New(() => externalId)
        )
        { }

        /// <summary>
        /// Grab a tecnomatix object by external id and cast it into a given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public EIDGrab(IScalar<TxProcessModelId> externalId) :base(() =>
            new TsConvert<T>(TxApplication.ActiveDocument.GetObjectByProcessModelId(externalId.Value())).Value()
        )
        {}
    }
}
