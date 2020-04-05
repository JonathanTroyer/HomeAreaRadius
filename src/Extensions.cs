
using UnityEngine;
using Verse;

namespace HomeAreaRadius
{
    public static class SettingsExtensions
    {
        private const float BaseLineHeight = 30f;

        public static void SliderLabeled(this Listing_Standard ls, string label, ref float val, float min, float max, string format = null, string tooltip = null)
        {
            // Backup original values
            TextAnchor backupAnchor = Text.Anchor;
            // Wrapper
            Rect rectWrapper = ls.GetRect(BaseLineHeight);
            Rect rectLeft = rectWrapper.LeftHalf();
            Rect rectRight = rectWrapper.RightHalf();
            if (tooltip != null)
            {
                TooltipHandler.TipRegion(rectLeft, tooltip);
            }
            // Left
            Text.Anchor = TextAnchor.MiddleLeft;
            Widgets.Label(rectLeft, label);
            // Right
            string sliderLabel = (format != null) ? val.ToString(format) : val.ToString();
            val = Widgets.HorizontalSlider(rectRight, val, min, max, true, sliderLabel);
            // Restore original values
            Text.Anchor = backupAnchor;
        }
        public static void SliderLabeled(this Listing_Standard ls, string label, ref int val, int min, int max, string format = null, string tooltip = null)
        {
            float valFloat = val;
            ls.SliderLabeled(label, ref valFloat, min, max, format, tooltip);
            val = (int)valFloat;
        }
    }
}
