using QSB.Syncs.Sectored.Transforms;
using UnityEngine;

namespace QSBMultipleShips.TransformSyncs;

internal class ShipRightLandingGearTransformSync : SectoredTransformSync
{
	protected override bool UseInterpolation => true;
	protected override bool IsPlayerObject => true;

	protected override Transform InitLocalTransform()
	{
		Player.SetCustomData("RightLandingGear", this);
		SectorDetector.Init(Locator.GetShipDetector().GetComponent<SectorDetector>());
		return Locator.GetShipTransform().Find("Module_LandingGear/LandingGear_Right");
	}

	protected override Transform InitRemoteTransform()
	{
		Player.SetCustomData("RightLandingGear", this);
		var shipModel = Locator.GetShipTransform();

		var remoteTransform = new GameObject("RemoteShip-RightLandingGear").transform;

		var LandingGear_Right = Instantiate(shipModel.Find("Module_LandingGear/LandingGear_Right"), remoteTransform);
		Destroy(LandingGear_Right.Find("Geo_LandingGear_Right/LandingGear_RightCollision").gameObject);
		Destroy(LandingGear_Right.Find("Systems_LandingGear_Right").gameObject);
		Destroy(LandingGear_Right.Find("Effects_LandingGear_Right").gameObject);
		Destroy(LandingGear_Right.GetComponent<ShipDetachableLeg>());

		return remoteTransform;
	}
}
