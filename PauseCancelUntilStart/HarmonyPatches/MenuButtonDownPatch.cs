using AutoPauseStealth;
using HarmonyLib;

namespace PauseCancelUntilStart.HarmonyPatches
{
    [HarmonyPatch(typeof(VRControllersInputManager))]
    [HarmonyPatch("MenuButtonDown", MethodType.Normal)]
    public class MenuButtonDownPatch
    {
        static void Postfix(ref bool __result)
        {
            if (AutoPauseStealthController.StabilityPeriodActive)
                __result = false;
        }
    }
}
