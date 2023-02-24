using InspectorGadget.Core.Model;
using InspectorGadget.Entity;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tecnomatix.Engineering;
using TmxSmarts;
using TmxSmarts.Object;
using Yaapii.Atoms.Enumerable;

namespace InspectorGadget.Tmx.Plugin.Api.Location
{
    /// <summary>
    /// Translates the all locations of the given programs by given delta
    /// </summary>
    public sealed class Translate : IRequestHandler<Translate.Request>
    {
        private readonly ICore core;

        /// <summary>
        /// Translates the all locations of the given programs by given delta
        /// </summary>
        public Translate(ICore core)
        {
            this.core = core;
        }

        public Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            try
            {
                TxApplication.ActiveDocument.UndoManager.StartTransaction();
                var delta = new TxVector(request.DeltaX, request.DeltaY, request.DeltaZ);
                IEnumerable<IProgram> programs = core.Programs();
                if (request.ProgramIds.Count() > 0)
                {
                    programs = Filtered.New(program => request.ProgramIds.Contains(program.Id()), programs);
                }

                foreach (var program in programs)
                {
                    foreach (var location in program.Locations())
                    {
                        var position =
                            new TxTransformation(
                                //TODO: Implement a TuLocatableObject class to make access simpler
                                new TuLocatableObject(location.Id()).Value().AbsoluteLocation.Translation + delta,
                                new TuLocatableObject(location.Id()).Value().AbsoluteLocation.RotationRPY_XYZ, TxTransformation.TxRotationType.RPY_XYZ
                            );
                        new EIDGrab<ITxLocatableObject>(location.Id()).Value().AbsoluteLocation = position;
                    }
                }
                TxApplication.RefreshDisplay();
                return Unit.Task;
            }
            finally
            {
                TxApplication.ActiveDocument.UndoManager.EndTransaction();
            }
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

            public Request(double[] delta, params string[] programIds) :this(
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
