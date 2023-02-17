using System.Collections.Generic;

namespace InspectorGadget.Entity
{
    public interface IProgram
    {
        /// <summary>
        /// Id of the program
        /// Usually the ExternalId from Tecnomatix
        /// </summary>
        string Id();
        /// <summary>
        /// Name of the program
        /// </summary>
        string Name();
        /// <summary>
        /// Properties if the program
        /// </summary>
        /// <returns></returns>
        IProps Props();
        /// <summary>
        /// The robot associated with the program
        /// </summary>
        IRobot Robot();
        /// <summary>
        /// The Locations of the program
        /// </summary>
        IList<ILocation> Locations();
    }
}
