using QSB.Syncs.Sectored.Transforms;
using UnityEngine;

namespace QSBMultipleShips.TransformSyncs;

internal class ShipEngineTransformSync : SectoredTransformSync
{
	protected override bool UseInterpolation => true;
	protected override bool IsPlayerObject => true;

	protected override Transform InitLocalTransform()
	{
		Player.SetCustomData("Engine", this);
		SectorDetector.Init(Locator.GetShipDetector().GetComponent<SectorDetector>());
		return Locator.GetShipTransform().Find("Module_Engine");
	}

	protected override Transform InitRemoteTransform()
	{
		Player.SetCustomData("Engine", this);
		var shipModel = Locator.GetShipTransform();

		var remoteTransform = new GameObject("RemoteShip-Engine").transform;

		var Geo_Cockpit = Instantiate(shipModel.Find("Module_Engine/Geo_Engine"), remoteTransform);
		Destroy(Geo_Cockpit.Find("Engine_Colliders").gameObject);

		return remoteTransform;
	}
}
