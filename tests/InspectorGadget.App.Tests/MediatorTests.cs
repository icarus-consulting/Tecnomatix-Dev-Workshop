using InspectorGadget.App.Api;
using InspectorGadget.Core;
using InspectorGadget.Entity.Program;
using InspectorGadget.Entity.Props;
using InspectorGadget.Entity.Robot;
using Xunit;

namespace InspectorGadget.App.Tests
{
    public class MediatorTests
    {
        [Fact]
        public async void HandlesRequest()
        {
            Assert.NotEmpty(
                await new InspectApi(
                    new InspectCore(
                        new SimpleProgram(
                            "123","my-prog",
                            new SimpleProps(),
                            new SimpleRobot("rob-123","iRobot", new SimpleProps())
                        )   
                    ),
                    typeof(Print.Request)
                )
                .Value()
                .Send(new Print.Request("xml"))
            );    
        }
    }
}