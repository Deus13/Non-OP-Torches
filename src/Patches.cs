using HarmonyLib;
using System;

namespace NonOPTorches
{
    [HarmonyPatch(typeof(TorchItem), "GetModifiedBurnLifetimeMinutes")]
    internal static class TorchItem_GetModifiedBurnLifetimeMinutes
    {
        private static void Postfix(ref float __result)
        {
            __result *= Settings.instance.burntime;
        }
    }

    [HarmonyPatch(typeof(TorchItem), "Extinguish", new Type[] { typeof(TorchState) })]
    internal static class TorchItem_Extinguish
    {
        private static void Prefix(TorchItem __instance, ref TorchState newState)
        {
            if (newState == TorchState.Extinguished && __instance.m_GearItem.GetNormalizedCondition() < (float) Settings.instance.BreakingThreshhold / 100f)
            {
                newState = TorchState.BurnedOut;
            }
        }

    }

    [HarmonyPatch(typeof(TorchItem), "Ignite", new Type[] { typeof(string) })]
    internal static class TorchItem_Ignite
    {
        private static TorchState tmpstate;
        private static bool flag;
        private static void Prefix(TorchItem __instance)
        {
            flag = false;
            var settings = Settings.instance;
            if (__instance.IsFresh() && __instance.m_GearItem.GetNormalizedCondition() < 0.5f) return;
            if (__instance.IsIgnitedFromFire()) return;

            if (UnityEngine.Random.Range(0f, 100f) <
                settings.BaseChance - 100 * (1f - __instance.m_GearItem.GetNormalizedCondition()) * settings.malusCondtion +
                (float) (GameManager.GetSkillFireStarting().GetCurrentTierNumber() * settings.BonusSkill))
            {
                return;
            }
            else
            {
                flag = true;
                tmpstate = __instance.m_State;
                __instance.m_State = TorchState.Burning;
            }
        }
        private static void Postfix(TorchItem __instance)
        {
            if (flag)
            {
                __instance.m_State = tmpstate;
            }
        }
    }
}
