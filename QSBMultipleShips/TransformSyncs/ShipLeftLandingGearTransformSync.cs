using QSB.Syncs.Sectored.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QSBMultipleShips.TransformSyncs;

internal class ShipLeftLandingGearTransformSync : SectoredTransformSync
{
	protected override bool UseInterpolation => true;
	protected override bool IsPlayerObject => true;

	protected override Transform InitLocalTransform()
	{
		Player.SetCustomData("LeftLandingGear", this);
		SectorDetector.Init(Locator.GetShipDetector().GetComponent<SectorDetector>());
		return Locator.GetShipTransform().Find("Module_LandingGear/LandingGear_Left");
	}

	protected override Transform InitRemoteTransform()
	{
		Player.SetCustomData("LeftLandingGear", this);
		var shipModel = Locator.GetShipTransform();

		var remoteTransform = new GameObject("RemoteShip-LeftLandingGear").transform;

		var LandingGear_Left = Instantiate(shipModel.Find("Module_LandingGear/LandingGear_Left"), remoteTransform);
		Destroy(LandingGear_Left.Find("Geo_LandingGear_Left/LandingGear_LeftCollision").gameObject);
		Destroy(LandingGear_Left.Find("Systems_LandingGear_Left").gameObject);
		Destroy(LandingGear_Left.Find("Effects_LandingGear_Left").gameObject);
		Destroy(LandingGear_Left.GetComponent<ShipDetachableLeg>());

		return remoteTransform;
	}
}
