using MelonLoader;
using UnityEngine;

namespace NonOPTorches
{
	internal class NonOPTorchesMod : MelonMod
	{

		public override void OnApplicationStart()
		{
			NonOPTorchesSettings.Settings.OnLoad();
			Debug.Log($"[{InfoAttribute.Name}] version {InfoAttribute.Version} loaded!");
		}
	}
}
