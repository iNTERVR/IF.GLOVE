using InterVR.IF.Glove.Components;

namespace InterVR.IF.Glove.Extensions
{
    public static class IF_Glove_HandExtensions
    {
        public static bool IsActive(this IF_Glove_Hand vrHand)
        {
            return vrHand.Active.Value;
        }

        public static void SetVisibility(this IF_Glove_Hand vrHand, bool state)
        {
            if (vrHand.RenderModel)
                vrHand.RenderModel.SetActive(state);
        }

        public static bool IsVisibility(this IF_Glove_Hand vrHand)
        {
            if (vrHand.RenderModel == null)
                return false;
            return vrHand.RenderModel.activeSelf;
        }
    }
}