using InterVR.IF.VR.Glove.Defines;
using EcsRx.Components;
using InterVR.IF.VR.Defines;

namespace InterVR.IF.VR.Glove.Components
{
    public class IF_VR_Glove_Wrist : IComponent
    {
        public IF_VR_HandType Type { get; set; }
    }
}