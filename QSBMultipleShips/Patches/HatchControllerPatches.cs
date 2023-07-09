using HarmonyLib;
using QSB.Messaging;
using QSB.Patches;
using QSBMultipleShips.Messages;

namespace QSBMultipleShips.Patches;

[HarmonyPatch(typeof(HatchController))]
internal class HatchControllerPatches : QSBPatch
{
	public override QSBPatchTypes Type => QSBPatchTypes.OnClientConnect;

	[HarmonyPrefix]
	[HarmonyPatch(nameof(HatchController.OpenHatch))]
	public static void OpenHatch() => new HatchMessage(true).Send();

	[HarmonyPrefix]
	[HarmonyPatch(nameof(HatchController.CloseHatch))]
	public static void CloseHatch() => new HatchMessage(false).Send();
}
