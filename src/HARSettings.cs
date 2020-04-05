using UnityEngine;
using Verse;

namespace HomeAreaRadius
{
    public class HARSettings : ModSettings
    {
        public static int homeAreaRadius = 4;

        public HARSettings() : base() { }

        public void DoWindowContents(Rect rect)
        {
            Listing_Standard ls = new Listing_Standard();
            ls.Begin(rect);
            ls.SliderLabeled("HAR_SettingsRadiusLabel".Translate(), ref homeAreaRadius, 0, 10, "###", "HAR_SettingsRadiusDescription".Translate());
            ls.End();
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref homeAreaRadius, "homeAreaRadius", 4);
        }
    }
}
