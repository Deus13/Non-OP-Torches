using ModSettings;

namespace NonOPTorches
{
    internal class Settings : JsonModSettings
    {
        public static Settings instance = new Settings();

        [Name("Base Chance Lighting")]
        [Description("Base Chance lighting a torch. The chance will be set to 100% if a fire is used to ignite. (100=Vanilla) ")]
        [Slider(0, 100f)]
        public float BaseChance = 80f;
        
        [Name("Chance Reduction for Condition")]
        [Description("How much the lighting chances are reduced by missing condition points of the torch. (0=Vanilla) ")]
        [Slider(0, 5f)]
        public float malusCondtion = 2f;

        [Name("Chance Bonus for Skill")]
        [Description("How much the lighting chances are increased for every Skillpoint in Firestarting. (0=Vanilla) ")]
        [Slider(0, 15)]
        public int BonusSkill = 5;

        [Name("Breaking Threshold")]
        [Description("Torches with lower condition than this threshhold will break on extinguishing. If set to 50% or above, torches pulled from fires will never be able to be relit, only harvested for sticks. (0=Vanilla) ")]
        [Slider(0, 100f)]
        public int BreakingThreshhold = 50;

        [Name("Burn Time Bonus")]
        [Description("Multiplies the burn time of torches. (1=Vanilla) ")]
        [Slider(0, 3f)]
        public float burntime = 1.5f;
    }
}
