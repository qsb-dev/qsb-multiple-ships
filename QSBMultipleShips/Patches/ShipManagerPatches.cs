using HarmonyLib;
using QSB.Patches;
using QSB.ShipSync;
using QSB.Utility;

namespace QSBMultipleShips.Patches;

[HarmonyPatch(typeof(ShipManager))]
internal class ShipManagerPatches : QSBPatch
{
	public override QSBPatchTypes Type => QSBPatchTypes.OnClientConnect;

	[HarmonyPrefix]
	[HarmonyPatch(nameof(ShipManager.BuildWorldObjects))]
	[HarmonyPatch("UpdateElectricalComponent")]
	public static bool SkipMethod() => false;
}
