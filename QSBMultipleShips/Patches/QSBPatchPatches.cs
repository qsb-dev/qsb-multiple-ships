using HarmonyLib;
using QSB.Patches;
using QSB.ShipSync;
using QSB.ShipSync.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSBMultipleShips.Patches;

[HarmonyPatch(typeof(QSBPatch))]
internal class QSBPatchPatches : QSBPatch
{
	public override QSBPatchTypes Type => QSBPatchTypes.OnModStart;

	[HarmonyPrefix]
	[HarmonyPatch(nameof(QSBPatch.DoPatches))]
	public static bool DoPatches(QSBPatch __instance)
	{
		if (__instance is ShipAudioPatches or ShipPatches or ShipDetachableModulePatches or ShipFlameWashPatches)
		{
			return false;
		}

		return true;
	}
}
