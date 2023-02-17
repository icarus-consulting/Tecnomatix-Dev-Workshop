using InspectorGadget.App.Api;
using InspectorGadget.Core.Model;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.Scalar;

namespace InspectorGadget.App
{
    public sealed class InspectApi : ScalarEnvelope<IMediator>
    {

        public InspectApi(ICore core, params Type[] useCases) : this(
          core,
          ManyOf.New(useCases)
        )
        { }

        public InspectApi(ICore core,  IEnumerable<Type> useCases) : base(() =>
        {
            var services = new ServiceCollection();
            services.AddSingleton(core);

            services.AddMediatR(
                useCases.ToArray()
            );

            return services.BuildServiceProvider().GetRequiredService<IMediator>();
        })
        { }
    }
}
