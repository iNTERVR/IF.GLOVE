using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace InterVR.IF.Glove.Installer
{
    public class IF_Glove_MonoInstaller : MonoInstaller<IF_Glove_MonoInstaller>
    {
        public List<ScriptableObjectInstaller> settings;

        public override void InstallBindings()
        {
            var settingsInstaller = settings.Cast<IInstaller>();
            foreach (var installer in settingsInstaller)
            {
                Container.Inject(installer);
                installer.InstallBindings();
            }
        }
    }
}