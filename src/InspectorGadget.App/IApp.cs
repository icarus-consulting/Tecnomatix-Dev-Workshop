using InspectorGadget.Entity;
using MediatR;
using System.Collections.Generic;

namespace InspectorGadget.App
{
    public interface IApp
    {
        IMediator Api();

        IEnumerable<IProgram> Programs();
    }
}
