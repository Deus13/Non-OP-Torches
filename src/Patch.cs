using Harmony;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NonOPTorches
{
    [HarmonyPatch(typeof(TorchItem), "GetModifiedBurnLifetimeMinutes")]
    internal static class TorchItem_GetModifiedBurnLifetimeMinutes
    {

        private static void Postfix(ref float __result)
        {

            __result *= NonOPTorchesSettings.Settings.options.burtime;
        }

    }

    [HarmonyPatch(typeof(TorchItem), "Extinguish", new Type[] { typeof(TorchState) })]
    internal static class TorchItem_Extinguish
    {

        private static void Prefix(TorchItem __instance, ref TorchState newState, GearItem ___m_GearItem)
        {
            var Settings = NonOPTorchesSettings.Settings.options;
            if (___m_GearItem.GetNormalizedCondition() < (float)Settings.BreakingThreshhold / 100f) if (newState == TorchState.Extinguished) newState = TorchState.BurnedOut;



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
            var Settings = NonOPTorchesSettings.Settings.options;
            if (__instance.IsFresh() && __instance.m_GearItem.GetNormalizedCondition() < 0.5f) return;
            if (__instance.IsIgnitedFromFire()) return;
            if (UnityEngine.Random.Range(0f, 100f) < Settings.BaseChance - 100 * (1f - __instance.m_GearItem.GetNormalizedCondition()) * Settings.malusCondtion + (float)(GameManager.GetSkillFireStarting().GetCurrentTierNumber() * Settings.BonusSkill)) return;
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
