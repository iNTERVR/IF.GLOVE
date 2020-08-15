using InterVR.IF.Glove.Defines;
using System;
using UnityEngine;
using Zenject;

namespace InterVR.IF.Glove.Installer
{
    [CreateAssetMenu(fileName = "IF_Glove_Settings", menuName = "InterVR/IF/Glove/Settings")]
    public class IF_Glove_Installer : ScriptableObjectInstaller<IF_Glove_Installer>
    {
#pragma warning disable 0649
        [SerializeField]
        Settings settings;
#pragma warning restore 0649

        public override void InstallBindings()
        {
            Container.BindInstance(settings).IfNotBound();
        }

        [Serializable]
        public class Settings
        {
            public string Name = "IF Glove Installer";
        }
    }
}