using BriX;
using InspectorGadget.Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Yaapii.Atoms.Enumerable;

namespace InspectorGadget.App.Api.Location
{
    public sealed class Translate : IRequestHandler<Translate.Request>
    {
        private readonly ICore core;

        public Translate(ICore core)
        {
            this.core = core;
        }

        public Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            // TODO: Implement the translation of all location by a given delta independent of Tecnoamtix.
            // The current implementation is tighly coupled to Tecnomatix which makes it hard to test.
            // To decouple to modification we have to do the following steps:
            // 1: Modify the transformation property of the locations inside the docuemnt.
            //      - You can either use XML,JSON or YAML... it's up to you which fits you  better.
            // 2: Introduce an Implementations for ILocation which reads the data from the Document provided by the Core.
            //      - e.g. XmlLocation : ILocation { ... }
            // 3: Update the Program entity by creating a new object with new SimpleProgram(..) and put the locations into the program
            // 4: Call core.Update(programs) to tell the core there is new data.
            // 5: Add an Api usecase to import the current Document into Tecnomatix
            throw new NotImplementedException();
        }


        /// <summary>
        /// Request for Tranlsation use case
        /// </summary>
        public sealed class Request : IRequest
        {
            public IEnumerable<string> ProgramIds { get; }
            public double DeltaX { get; }
            public double DeltaY { get; }
            public double DeltaZ { get; }

            public Request(double[] delta, params string[] programIds) : this(
                delta[0],
                delta[1],
                delta[2],
                programIds
            )
            { }

            /// <summary>
            /// Request for Tranlsation use case
            /// </summary>
            public Request(double deltaX, double deltaY, double deltaZ, params string[] programIds) : this(
                ManyOf.New(programIds),
                deltaX,
                deltaY,
                deltaZ
            )
            { }

            private Request(IEnumerable<string> programIds, double deltaX, double deltaY, double deltaZ)
            {
                DeltaX = deltaX;
                DeltaY = deltaY;
                DeltaZ = deltaZ;
                ProgramIds = programIds;
            }
        }
    }
}
