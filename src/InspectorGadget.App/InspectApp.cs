using InspectorGadget.Core.Model;
using InspectorGadget.Entity;
using MediatR;
using System.Collections.Generic;
using Yaapii.Atoms;

namespace InspectorGadget.App
{
    public sealed class InspectApp : IApp
    {
        private readonly ICore core;
        private readonly IScalar<IMediator> api;

        public InspectApp(ICore core, IScalar<IMediator> api)
        {
            this.core = core;
            this.api = api;
        }
        public IMediator Api()
        {
            return this.api.Value();
        }

        public IEnumerable<IProgram> Programs()
        {
            return core.Programs();
        }
    }
}
