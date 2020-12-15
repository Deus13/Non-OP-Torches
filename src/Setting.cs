
using System;
using System.IO;
using System.Reflection;
using ModSettings;

namespace NonOPTorches
{
    internal class NonOPTorchesSettings : JsonModSettings
    {

        
        [Name("Breaking  Threshhold")]
        [Description("Torches with lower condition than this threshhold will break on extinguishing. If set to 50% or above, torches form fire will never be able to bet relit just harvested for sticks. (0=Vanilla) ")]
        [Slider(0, 100f)]
        public int BreakingThreshhold = 50;


        
        [Name("Base Chance lighting")]
        [Description("Base Chance lighting a torch. Chance will be set to 100% if fire is used to ignite. (100=Vanilla) ")]
        [Slider(0, 100f)]
        public float BaseChance = 80f;


        [Name("Chance malus for condtion")]
        [Description("How much the lighting chances are reduced by missing condition point of the torch. (0=Vanilla) ")]
        [Slider(0, 5f)]
        public float malusCondtion = 2f;

        [Name("Chance Bonus for Skill")]
        [Description("How much the lighting chances are increased for every Skillpiont in Firestarting. (0=Vanilla) ")]
        [Slider(0, 15)]
        public int BonusSkill = 5;

        [Name("Bunrtimebonus")]
        [Description("Multiplies the burn time . (1=Vanilla) ")]
        [Slider(0, 3f)]
        public float burtime = 1.5f;


        internal static class Settings
        {
            public static NonOPTorchesSettings options;
            public static void OnLoad()
            {
                options = new NonOPTorchesSettings();
                options.RefreshGUI();
                options.AddToModSettings("None OP Torches Settings");
            }
        }
    }
}
