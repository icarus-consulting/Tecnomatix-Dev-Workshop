using BriX;
using InspectorGadget.Core.Brix;
using InspectorGadget.Core.Model;
using InspectorGadget.Entity;
using System.Collections.Generic;
using Yaapii.Atoms.Enumerable;

namespace InspectorGadget.Core
{
    public sealed class InspectCore : ICore
    {
        private readonly List<IProgram> programs;

        public InspectCore(params IProgram[] programs) : this(ManyOf.New(programs))
        { }

        public InspectCore(IEnumerable<IProgram> programs)
        {
            this.programs = new List<IProgram>(programs);
        }
        

        public IList<IProgram> Programs()
        {
            return this.programs;
        }

        public void Update(IEnumerable<IProgram> programs)
        {
            this.programs.Clear();
            this.programs.AddRange(programs);
        }


        public IBrix Content()
        {
            IBrix result = new BxNothing();
            if (programs.Count > 0)
            {
                result =
                    new BxBlockArray(
                    "programs",
                    "program",
                    Yaapii.Atoms.Enumerable.Mapped.New(
                        program => new BxProgram(program),
                        programs
                    )
                );
            }
            return result;

        }
    }
}
