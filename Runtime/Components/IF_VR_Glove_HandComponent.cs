using EcsRx.Components;
using EcsRx.Entities;
using EcsRx.UnityEditor.MonoBehaviours;
using InterVR.IF.VR.Defines;
using UniRx;
using UnityEngine;

namespace InterVR.IF.VR.Glove.Components
{
    public class IF_VR_Glove_Hand : IComponent
    {
        public IF_VR_HandType Type { get; set; }
        public Transform Wrist { get; set; }
        public IEntity WristEntity { get; set; }
        public bool Connected { get; set; }
        public BoolReactiveProperty Active { get; set; }

        public const float MaxDisconnectStateTimeSeconds = 1.0f;
        public bool GoingToDisconnect { get; set; }
        public float DisconnectStateTimer { get; set; }
        public GameObject RenderModel { get; set; }

        public IF_VR_Glove_Hand()
        {
            Active = new BoolReactiveProperty(false);
        }

        public void Dispose()
        {
            Active.Dispose();
        }
    }
}