using EcsRx.Infrastructure.Dependencies;
using EcsRx.Infrastructure.Extensions;

namespace InterVR.IF.Glove.Modules
{
    public class IF_Glove_ToolModules : IDependencyModule
    {
        public void Setup(IDependencyContainer container)
        {
            container.Bind<IF_Glove_IInterface, IF_Glove_Interface>();
        }
    }
}