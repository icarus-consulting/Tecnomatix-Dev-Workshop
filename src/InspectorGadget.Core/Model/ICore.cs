using BriX;
using InspectorGadget.Entity;
using System.Collections.Generic;

namespace InspectorGadget.Core.Model
{
    public interface ICore
    {
        IList<IProgram> Programs();

        void Update(IEnumerable<IProgram> programs);

        IBrix Content();

        //string Print(string format = "xml");
    }
}
