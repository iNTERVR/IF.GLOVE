using EcsRx.Infrastructure.Dependencies;
using EcsRx.Infrastructure.Extensions;

namespace InterVR.IF.VR.Glove.Modules
{
    public class IF_VR_Glove_ToolModules : IDependencyModule
    {
        public void Setup(IDependencyContainer container)
        {
            container.Bind<IF_VR_Glove_IInterface, IF_VR_Glove_Interface>();
        }
    }
}