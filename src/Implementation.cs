using MelonLoader;
using UnityEngine;


namespace NonOPTorches
{
    public class Implementation : MelonMod
    {
        public static double HPnotround = 0f;

        public override void OnApplicationStart()
        {
            Debug.Log($"[{Info.Name}] version {Info.Version} loaded!");
            Settings.instance.RefreshGUI();
            Settings.instance.AddToModSettings("Non OP Torches Settings");
        }
    }
}