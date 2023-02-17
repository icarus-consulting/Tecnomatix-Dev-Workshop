using System;
using Tecnomatix.Engineering;
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
        public TsConvert(ITxObject input) : base(() =>
        {
            if(input is not T)
            {
                throw new InvalidCastException($"Cannot convert '{input.GetType().Name}' to '{typeof(T).Name}'");
            }

            return (T)input;
        })
        { }
    }
}
