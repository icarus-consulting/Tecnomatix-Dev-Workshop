using System;
using Tecnomatix.Engineering;
using Yaapii.Atoms;
using Yaapii.Atoms.Scalar;

namespace TmxSmarts
{
    /// <summary>
    /// Converts a <see cref="ITxObject"/> to given type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class TsConvert<T> : ScalarEnvelope<T> where T : ITxObject
    {
        /// <summary>
        /// Converts a <see cref="ITxObject"/> to given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public TsConvert(ITxObject input) :this(
            ScalarOf.New(input)
        )
        { }

        /// <summary>
        /// Converts a <see cref="ITxObject"/> to given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public TsConvert(IScalar<ITxObject> input) : base(() =>
        {
            var val = input.Value();
            if(val is not T)
            {
                throw new InvalidCastException($"Cannot convert '{val.GetType().Name}' to '{typeof(T).Name}'");
            }

            return (T)val;
        })
        { }
    }
}
