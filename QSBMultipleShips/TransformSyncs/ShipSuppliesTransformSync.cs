using QSB.Syncs.Sectored.Transforms;
using UnityEngine;

namespace QSBMultipleShips.TransformSyncs;

internal class ShipSuppliesTransformSync : SectoredTransformSync
{
	protected override bool UseInterpolation => true;
	protected override bool IsPlayerObject => true;

	protected override Transform InitLocalTransform()
	{
		Player.SetCustomData("Supplies", this);
		SectorDetector.Init(Locator.GetShipDetector().GetComponent<SectorDetector>());
		return Locator.GetShipTransform().Find("Module_Supplies");
	}

	protected override Transform InitRemoteTransform()
	{
		Player.SetCustomData("Supplies", this);
		var shipModel = Locator.GetShipTransform();

		var remoteTransform = new GameObject("RemoteShip-Cockpit").transform;

		var Geo_Cockpit = Instantiate(shipModel.Find("Module_Supplies/Geo_Supplies"), remoteTransform);
		Destroy(Geo_Cockpit.Find("Supplies_Colliders").gameObject);

		return remoteTransform;
	}
}
