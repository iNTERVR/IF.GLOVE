using InterVR.IF.Glove.Defines;
using EcsRx.Components;
using EcsRx.Entities;
using EcsRx.Extensions;
using System;
using UniRx;
using UnityEngine;

namespace InterVR.IF.Glove.Components
{
    public class IF_Glove_Hand : IComponent, IDisposable
    {
        public IF_Glove_HandType Type { get; set; }
        public Transform Wrist { get; set; }
        public IEntity WristEntity { get; set; }
        public bool Connected { get; set; }
        public BoolReactiveProperty Active { get; set; }

        public const float MaxDisconnectStateTimeSeconds = 1.0f;
        public bool GoingToDisconnect { get; set; }
        public float DisconnectStateTimer { get; set; }
        public GameObject RenderModel { get; set; }

        public IF_Glove_Hand()
        {
            Active = new BoolReactiveProperty(false);
        }

        public void Dispose()
        {
            Active.Dispose();
        }
    }

    public class IF_Glove_HandComponent : MonoBehaviour, IConvertToEntity
    {
        public IF_Glove_HandType Type;
        public Transform Wrist;

        public void Convert(IEntity entity, IComponent component = null)
        {
            var c = component == null ? new IF_Glove_Hand() : component as IF_Glove_Hand;

            c.Type = Type;
            c.Wrist = Wrist;

            entity.AddComponentSafe(c);

            Destroy(this);
        }
    }
}