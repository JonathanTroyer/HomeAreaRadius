using HarmonyLib;
using System.Reflection;
using Verse;


namespace HomeAreaRadius
{
    [StaticConstructorOnStartup]
    class Setup
    {
        static Setup()
        {
            var harmony = new Harmony("rimworld.neptimus7.homearearadius");
            Harmony.DEBUG = true;
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
