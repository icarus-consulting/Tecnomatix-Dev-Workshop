using System.Collections.Generic;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.List;

namespace InspectorGadget.Entity.Program
{
    /// <summary>
    /// A simple <see cref="IProgram"/>
    /// </summary>
    public sealed class SimpleProgram : ProgramEnvelope
    {
        /// <summary>
        /// A simple <see cref="IProgram"/>
        /// </summary>
        public SimpleProgram(string id, string name, IProps props, IRobot robot, params ILocation[] locations) : this(
            id,
            name,
            props,
            robot,
            ManyOf.New(locations)
        )
        { }

        /// <summary>
        /// A simple <see cref="IProgram"/>
        /// </summary>
        public SimpleProgram(string id, string name, IProps props, IRobot robot, IEnumerable<ILocation> locations) : base(
            id,
            name,
            props,
            robot,
            ListOf.New(locations)
        )
        { }
    }
}
