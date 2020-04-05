using HarmonyLib;
using RimWorld;
using Verse;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HomeAreaRadius
{
    [HarmonyPatch(typeof(AutoHomeAreaMaker))]
    [HarmonyPatch("MarkHomeAroundThing")]
    public static class Patch_AutoHomeAreaMaker_MarkHomeAroundThing
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            for(var i = 0; i < codes.Count; i++)
            {
                if(codes[i].opcode == OpCodes.Sub) {
                    var nextCode = i + 1 < codes.Count ? codes[i + 1] : null;
                    if(nextCode?.opcode == OpCodes.Ldc_I4_4)
                    {
                        nextCode.opcode = OpCodes.Ldc_I4;
                        nextCode.operand = HARSettings.homeAreaRadius;
                    }
                }
                else if (codes[i].opcode == OpCodes.Add) {
                    var prevCode = i - 1 >= 0 ? codes[i - 1] : null;
                    if(prevCode?.opcode == OpCodes.Ldc_I4_8)
                    {
                        prevCode.opcode = OpCodes.Ldc_I4;
                        prevCode.operand = HARSettings.homeAreaRadius * 2;
                    }
                }
            }

            Log.Message("Patched MarkHomeAroundThing with radius " + HARSettings.homeAreaRadius);

            return codes;
        }
    }

    [HarmonyPatch(typeof(AutoHomeAreaMaker))]
    [HarmonyPatch("Notify_ZoneCellAdded")]
    public static class Patch_AutoHomeAreaMaker_Notify_ZoneCellAdded
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            for (var i = 0; i < codes.Count; i++)
            {
                if(codes[i].opcode == OpCodes.Ldc_I4_4)
                {
                    codes[i].opcode = OpCodes.Ldc_I4;
                    codes[i].operand = HARSettings.homeAreaRadius;
                }
            }

            Log.Message("Patched Notify_ZoneCellAdded with radius " + HARSettings.homeAreaRadius);

            return codes;
        }
    }
}
