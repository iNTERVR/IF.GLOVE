using EcsRx.Groups;
using EcsRx.Events;
using UniRx;
using System.Collections.Generic;
using System;
using EcsRx.Extensions;
using EcsRx.Collections.Database;
using EcsRx.Unity.Extensions;
using InterVR.IF.VR.Components;
using EcsRx.Plugins.ReactiveSystems.Systems;
using EcsRx.Entities;
using UniRx.Triggers;
using EcsRx.Plugins.Views.Components;
using InterVR.IF.VR.Modules;
using InterVR.IF.VR.Glove.Modules;
using UnityEngine;
using InterVR.IF.Modules;
using InterVR.IF.VR.Defines;
using InterVR.IF.VR.Glove.Components;

namespace InterVR.IF.VR.Glove.Systems
{
    public class IF_VR_HandSystem : ISetupSystem, ITeardownSystem
    {
        public IGroup Group => new Group(typeof(IF_VR_Hand), typeof(ViewComponent));

        private List<IDisposable> subscriptions = new List<IDisposable>();
        private readonly IEntityDatabase entityDatabase;
        private readonly IF_VR_IInterface vrInterface;
        private readonly IF_VR_Glove_IInterface vrGloveInterface;
        private readonly IF_IGameObjectTool gameObjectTool;

        public IF_VR_HandSystem(IEntityDatabase entityDatabase,
            IF_VR_IInterface vrInterface,
            IF_VR_Glove_IInterface vrGloveInterface,
            IF_IGameObjectTool gameObjectTool)
        {
            this.entityDatabase = entityDatabase;
            this.vrInterface = vrInterface;
            this.vrGloveInterface = vrGloveInterface;
            this.gameObjectTool = gameObjectTool;
        }

        public void Setup(IEntity entity)
        {
            var hand = entity.GetComponent<IF_VR_Hand>();
            var glovesRoot = vrGloveInterface.GetRootTransform();
            if (glovesRoot == null)
            {
                var rootTransform = vrInterface.Rig.transform;
                var glovesRootGo = new GameObject("IF_VR_Gloves");
                gameObjectTool.SetParentWithInit(glovesRootGo, rootTransform);
                glovesRoot = glovesRootGo.transform;
                vrGloveInterface.SetRootTransform(glovesRoot);
            }

            createGloveEntity(glovesRoot, hand.Type);
        }

        public void Teardown(IEntity entity)
        {
            subscriptions.DisposeAll();
        }

        void createGloveEntity(Transform parent, IF_VR_HandType handType)
        {
            string gloveName = "IF_VR_Glove" + handType.ToString();
            var gloveGo = new GameObject(gloveName);
            var gloveWristGo = new GameObject(gloveName + "Wrist");

            gameObjectTool.SetParentWithInit(gloveGo, parent);
            gameObjectTool.SetParentWithInit(gloveWristGo, gloveGo.transform);

            var pool = entityDatabase.GetCollection();
            var gloveEntity = pool.CreateEntity();
            gloveGo.LinkEntity(gloveEntity, pool);
            gloveEntity.AddComponent(new IF_VR_Glove_Hand()
            {
                Type = handType,
                Wrist = gloveWristGo.transform
            });
        }
    }
}