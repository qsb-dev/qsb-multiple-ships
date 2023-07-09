using QSB.Syncs.Sectored.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QSBMultipleShips.TransformSyncs;
internal class ShipCockpitTransformSync : SectoredTransformSync
{
	protected override bool UseInterpolation => true;
	protected override bool IsPlayerObject => true;

	protected override Transform InitLocalTransform()
	{
		Player.SetCustomData("Cockpit", this);
		SectorDetector.Init(Locator.GetShipDetector().GetComponent<SectorDetector>());
		return Locator.GetShipTransform().Find("Module_Cockpit");
	}

	protected override Transform InitRemoteTransform()
	{
		Player.SetCustomData("Cockpit", this);
		var shipModel = Locator.GetShipTransform();

		var remoteTransform = new GameObject("RemoteShip-Cockpit").transform;

		var Geo_Cockpit = Instantiate(shipModel.Find("Module_Cockpit/Geo_Cockpit"), remoteTransform);
		Destroy(Geo_Cockpit.Find("Cockpit_Colliders").gameObject);
		Destroy(Geo_Cockpit.Find("Cockpit_Tech/Cockpit_Tech_Exterior/SignalDishPivot/SignalDish_Collision").gameObject);

		var Module_Cockpit = Geo_Cockpit.parent;
		Destroy(Module_Cockpit.GetComponent<ShipDetachableModule>());
		Destroy(Module_Cockpit.GetComponent<ShipHull>());

		return remoteTransform;
	}
}
