using InterVR.IF.VR.Defines;
using InterVR.IF.VR.Glove.Defines;
using UniRx;
using UnityEngine;

namespace InterVR.IF.VR.Glove.Modules
{
    public class IF_VR_Glove_Interface : IF_VR_Glove_IInterface
    {
        public FloatReactiveProperty HandYawOffsetLeft => throw new System.NotImplementedException();

        public FloatReactiveProperty HandYawOffsetRight => throw new System.NotImplementedException();

        public int PlayerNumber => throw new System.NotImplementedException();

        public bool GetGrabState(IF_VR_HandType handType)
        {
            throw new System.NotImplementedException();
        }

        public bool GetGrabStateDown(IF_VR_HandType handType)
        {
            throw new System.NotImplementedException();
        }

        public bool GetGrabStateUp(IF_VR_HandType handType)
        {
            throw new System.NotImplementedException();
        }

        public Transform GetRootTransform()
        {
            throw new System.NotImplementedException();
        }

        public void SetRootTransform(Transform root)
        {
            throw new System.NotImplementedException();
        }
    }
}