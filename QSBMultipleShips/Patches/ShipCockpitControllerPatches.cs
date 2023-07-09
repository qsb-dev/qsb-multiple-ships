using HarmonyLib;
using QSB.Messaging;
using QSB.Patches;
using QSB.Utility;
using QSBMultipleShips.Messages;

namespace QSBMultipleShips.Patches;

[HarmonyPatch(typeof(ShipCockpitController))]
internal class ShipCockpitControllerPatches : QSBPatch
{
	public override QSBPatchTypes Type => QSBPatchTypes.OnClientConnect;

	[HarmonyPostfix]
	[HarmonyPatch(nameof(ShipCockpitController.SetEnableShipLights))]
	public static void SetEnableShipLights(ShipCockpitController __instance, bool enableLights, bool playAudio)
	{
		DebugLog.DebugWrite($"SetEnableShipLights enableLights:{enableLights} usingLandingCam:{__instance._usingLandingCam}");
		new HeadlightMessage(enableLights && !__instance._usingLandingCam).Send();
		// TODO landing light
		if (playAudio)
		{
			// TODO headlight noise
		}
	}
}
