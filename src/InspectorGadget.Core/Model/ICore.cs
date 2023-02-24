using BriX;
using InspectorGadget.Entity;
using System.Collections.Generic;

namespace InspectorGadget.Core.Model
{
    /// <summary>
    /// The core which has the 
    /// </summary>
    public interface ICore
    {
        /// <summary>
        /// The current programs to inspect
        /// </summary>
        /// <returns></returns>
        IList<IProgram> Programs();

        /// <summary>
        /// Update the programs which are inspected
        /// </summary>
        /// <param name="programs"></param>
        void Update(IEnumerable<IProgram> programs);

        /// <summary>
        /// The content of the inspection as <see cref="IBrix"/>
        /// </summary>
        /// <returns></returns>
        IBrix Content();
    }
}
