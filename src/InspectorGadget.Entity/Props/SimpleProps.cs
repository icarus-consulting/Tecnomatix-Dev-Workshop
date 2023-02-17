using System;
using System.Collections.Generic;
using System.Linq;
using Yaapii.Atoms;
using Yaapii.Atoms.Scalar;

namespace InspectorGadget.Entity.Props
{
    public sealed class SimpleProps : IProps
    {
        private readonly IScalar<IDictionary<string, string>> props;

        public SimpleProps() : this(
            new Dictionary<string,string>()
        )
        { }

        public SimpleProps(IDictionary<string, string> props) : this(() => props)
        { }

        public SimpleProps(Func<IDictionary<string, string>> props)
        {
            this.props = ScalarOf.New(props);
        }
        public IList<string> Names()
        {
            return this.props.Value().Keys.ToList();
        }

        public IProps Refined(string name, string value)
        {
            if(!this.props.Value().ContainsKey(name))
            {
                this.props.Value().Add(name, value);
            } else
            {
                this.props.Value()[name] = value;
            }

            return new SimpleProps(props.Value());
        }

        public string Value(string name, Func<string> fallback)
        {
            var result = "";
            if (this.props.Value().ContainsKey(name))
            {
                result = this.props.Value()[name];
            } else
            {
                result = fallback();
            }

            return result;
        }

        public string Value(string name)
        {
            return
                this.Value(
                    name,
                    () => throw new InvalidOperationException($"Cannot get property '{name}' because it doesn't exist. Known properties are: {string.Join(", ", Names())}")
                );
        }
    }
}
