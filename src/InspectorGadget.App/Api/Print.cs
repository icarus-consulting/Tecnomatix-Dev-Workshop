using BriX.Media;
using InspectorGadget.Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Yaapii.Atoms.Enumerable;
using Yaapii.Atoms.Map;

namespace InspectorGadget.App.Api
{
    public sealed class Print : IRequestHandler<Print.Request, string>
    {
        private readonly IDictionary<string, string> print;

        public Print(ICore core)
        {
            this.print =
               FallbackMap.New(() =>
                   LiveMap.New(() =>
                       ManyOf.New(
                           KvpOf.New<string>("xml", () => core.Content().Print(new XmlMedia()).ToString()),
                           KvpOf.New<string>("json", () => core.Content().Print(new JsonMedia()).ToString()),
                           KvpOf.New<string>("yaml", () => core.Content().Print(new YamlMedia()).ToString())
                       )
                   ),
                   format => core.Content().Print(new XmlMedia()).ToString()
               );
        }
        public Task<string> Handle(Request request, CancellationToken cancellationToken)
        {
            var format = request.Format;
            var printed = this.print[format.ToLower()];
            // special treatment for json because an BxNothing will be printed as '{}' which is indeed an empty json structure but looks ugly in the UI
            if (format.Equals("json", StringComparison.InvariantCultureIgnoreCase) && printed.Equals("{}", StringComparison.InvariantCultureIgnoreCase))
            {
                printed = "";
            }
            return Task.FromResult(printed);

        }

        public sealed class Request : IRequest<string>
        {
            public Request(string format)
            {
                Format = format;
            }

            public string Format { get; }
        }
    }
}
