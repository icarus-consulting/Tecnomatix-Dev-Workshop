using System;
using System.Collections.Generic;

namespace InspectorGadget.Entity
{
    public interface IProps
    {
        IList<string> Names();
        string Value(string name);
        string Value(string name, Func<string> fallback);
        IProps Refined(string name, string value);

    }
}
