using UnityEngine;
using Verse;

namespace HomeAreaRadius
{
    public class HARMod : Mod
    {
        public HARSettings settings;
        public HARMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<HARSettings>();
        }

        public override void DoSettingsWindowContents(Rect rect)
        {
            settings.DoWindowContents(rect);
            settings.Write();
        }

        public override string SettingsCategory()
        {
            return "HAR_SettingsCategory".Translate();
        }

        public override void WriteSettings()
        {
            base.WriteSettings();
            HarmonySetup.RePatchAutoHomeAreaMaker();
        }
    }
}
