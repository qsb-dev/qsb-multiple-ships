using QSB.Syncs.Sectored.Transforms;
using UnityEngine;

namespace QSBMultipleShips.TransformSyncs;

internal class ShipFrontLandingGearTransformSync : SectoredTransformSync
{
	protected override bool UseInterpolation => true;
	protected override bool IsPlayerObject => true;

	public ShipLight Headlight { get; private set; }

	protected override Transform InitLocalTransform()
	{
		Player.SetCustomData("FrontLandingGear", this);
		SectorDetector.Init(Locator.GetShipDetector().GetComponent<SectorDetector>());
		return Locator.GetShipTransform().Find("Module_LandingGear/LandingGear_Front");
	}

	protected override Transform InitRemoteTransform()
	{
		Player.SetCustomData("FrontLandingGear", this);
		var shipModel = Locator.GetShipTransform();

		var remoteTransform = new GameObject("RemoteShip-FrontLandingGear").transform;

		var LandingGear_Front = Instantiate(shipModel.Find("Module_LandingGear/LandingGear_Front"), remoteTransform);
		Destroy(LandingGear_Front.Find("Geo_LandingGear_Front/LandingGear_FrontCollision").gameObject);
		Destroy(LandingGear_Front.Find("Systems_LandingGear_Front").gameObject);
		Destroy(LandingGear_Front.Find("Effects_LandingGear_Front").gameObject);
		Destroy(LandingGear_Front.GetComponent<ShipDetachableLeg>());

		Headlight = LandingGear_Front.Find("Lights_LandingGear_Front/SpotLight_HEA_Headlights").GetComponent<ShipLight>();
		Headlight._powered = true;

		return remoteTransform;
	}
}
