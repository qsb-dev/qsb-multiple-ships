using HarmonyLib;
using Mirror;
using QSB;
using QSB.Patches;

namespace QSBMultipleShips.Patches;

[HarmonyPatch(typeof(QSBNetworkManager))]
internal class QSBNetworkManagerPatches : QSBPatch
{
	public override QSBPatchTypes Type => QSBPatchTypes.OnModStart;

	[HarmonyPostfix]
	[HarmonyPatch(nameof(QSBNetworkManager.OnServerAddPlayer))]
	public static void OnServerAddPlayer(NetworkConnectionToClient connection)
	{
		NetworkServer.Spawn(UnityEngine.Object.Instantiate(Core.Instance.CockpitPrefab), connection);
		NetworkServer.Spawn(UnityEngine.Object.Instantiate(Core.Instance.CabinPrefab), connection);
		NetworkServer.Spawn(UnityEngine.Object.Instantiate(Core.Instance.FrontLandingPrefab), connection);
		NetworkServer.Spawn(UnityEngine.Object.Instantiate(Core.Instance.LeftLandingPrefab), connection);
		NetworkServer.Spawn(UnityEngine.Object.Instantiate(Core.Instance.RightLandingPrefab), connection);
		NetworkServer.Spawn(UnityEngine.Object.Instantiate(Core.Instance.SuppliesPrefab), connection);
		NetworkServer.Spawn(UnityEngine.Object.Instantiate(Core.Instance.EnginePrefab), connection);
	}
}
