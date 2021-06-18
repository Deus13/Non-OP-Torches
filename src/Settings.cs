using ModSettings;

namespace NonOPTorches
{
    internal class Settings : JsonModSettings
    {
        public static Settings instance = new Settings();

        [Name("Breaking Threshhold")]
        [Description("Torches with lower condition than this threshhold will break on extinguishing. If set to 50% or above, torches form fire will never be able to bet relit just harvested for sticks. (0=Vanilla) ")]
        [Slider(0, 100f)]
        public int BreakingThreshhold = 50;
        
        [Name("Base Chance lighting")]
        [Description("Base Chance lighting a torch. The chance will be set to 100% if fire is used to ignite. (100=Vanilla) ")]
        [Slider(0, 100f)]
        public float BaseChance = 80f;
        
        [Name("Chance Reduction for Condition")]
        [Description("How much the lighting chances are reduced by missing condition points of the torch. (0=Vanilla) ")]
        [Slider(0, 5f)]
        public float malusCondtion = 2f;

        [Name("Chance Bonus for Skill")]
        [Description("How much the lighting chances are increased for every Skillpiont in Firestarting. (0=Vanilla) ")]
        [Slider(0, 15)]
        public int BonusSkill = 5;

        [Name("Bunrtimebonus")]
        [Description("Multiplies the burn time . (1=Vanilla) ")]
        [Slider(0, 3f)]
        public float burntime = 1.5f;
    }
}
