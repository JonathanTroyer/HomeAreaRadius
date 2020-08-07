using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;


namespace HomeAreaRadius
{
    [StaticConstructorOnStartup]
    class HarmonySetup
    {
        static readonly Harmony harmony;
        static readonly PatchProcessor MarkHomeAroundThingPatchProcessor;
        static readonly PatchProcessor Notify_ZoneCellAddedPatchProcessor;

        static HarmonySetup()
        {
            harmony = new Harmony("rimworld.neptimus7.homearearadius");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            MarkHomeAroundThingPatchProcessor = new PatchProcessor(harmony, typeof(AutoHomeAreaMaker).GetMethod("MarkHomeAroundThing"));
            Notify_ZoneCellAddedPatchProcessor = new PatchProcessor(harmony, typeof(AutoHomeAreaMaker).GetMethod("Notify_ZoneCellAdded"));
        }

        public static void RePatchAutoHomeAreaMaker()
        {
            MarkHomeAroundThingPatchProcessor.Patch();
            Notify_ZoneCellAddedPatchProcessor.Patch();
        }
    }
}
