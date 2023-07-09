using QSB.Syncs.Sectored.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QSBMultipleShips.TransformSyncs;

internal class ShipCabinTransformSync : SectoredTransformSync
{
	protected override bool UseInterpolation => true;
	protected override bool IsPlayerObject => true;

	public CustomHatchController Hatch { get; private set; }

	protected override Transform InitLocalTransform()
	{
		Player.SetCustomData("Cabin", this);
		SectorDetector.Init(Locator.GetShipDetector().GetComponent<SectorDetector>());
		return Locator.GetShipTransform().Find("Module_Cabin");
	}

	protected override Transform InitRemoteTransform()
	{
		Player.SetCustomData("Cabin", this);
		var shipModel = Locator.GetShipTransform();

		var remoteTransform = new GameObject("RemoteShip-Cabin").transform;
		remoteTransform.gameObject.SetActive(false);

		var Geo_Cabin = Instantiate(shipModel.Find("Module_Cabin/Geo_Cabin"), remoteTransform);
		Destroy(Geo_Cabin.Find("Cabin_Colliders_Back").gameObject);
		Destroy(Geo_Cabin.Find("Cabin_Colliders_Top").gameObject);

		var Module_Cabin = Geo_Cabin.parent;
		Destroy(Module_Cabin.GetComponent<ShipModule>());
		foreach (var item in Module_Cabin.GetComponents<ShipHull>())
		{
			Destroy(item);
		}

		Hatch = Module_Cabin.gameObject.AddComponent<CustomHatchController>();
		Hatch._hatch = Geo_Cabin.Find("Cabin_Tech/Cabin_Tech_Exterior/HatchPivot");

		var Lights_Cabin = Instantiate(shipModel.Find("Module_Cabin/Lights_Cabin"), remoteTransform);
		Destroy(Lights_Cabin.Find("AmbientLight_PlayerShip").gameObject);
		Destroy(Lights_Cabin.Find("PointLight_HEA_MasterAlarm").gameObject);
		Destroy(Lights_Cabin.Find("PointLight_HEA_MasterAlarm").gameObject);
		Destroy(Lights_Cabin.Find("ShipBeacon_Proxy").GetComponent<SectorProxy>());
		var upperPulsingLight = Lights_Cabin.Find("ShipBeacon_Proxy/PointLight_HEA_ShipBeaconUpper").GetComponent<PulsingLight>();
		var newUpperPulsingLight = Lights_Cabin.Find("ShipBeacon_Proxy/PointLight_HEA_ShipBeaconUpper").gameObject.AddComponent<CustomPulsingLight>();
		newUpperPulsingLight._emissiveRenderer = upperPulsingLight._emissiveRenderer;
		newUpperPulsingLight._materialIndex = upperPulsingLight._materialIndex;
		newUpperPulsingLight._pulseRate = upperPulsingLight._pulseRate;
		newUpperPulsingLight._intensityFluctuation = upperPulsingLight._intensityFluctuation;
		newUpperPulsingLight._rangeFluctuation = upperPulsingLight._rangeFluctuation;
		newUpperPulsingLight._timeOffset = upperPulsingLight._timeOffset;
		newUpperPulsingLight._initLightIntensity = 0.5f;
		newUpperPulsingLight._initLightRange = 10;
		newUpperPulsingLight._initEmissionColor = new Color(1, 0.8496957f, 0.5808822f, 1);
		Destroy(upperPulsingLight);

		var lowerPulsingLight = Lights_Cabin.Find("ShipBeacon_Proxy/PointLight_HEA_ShipBeaconLower").GetComponent<PulsingLight>();
		var newLowerPulsingLight = Lights_Cabin.Find("ShipBeacon_Proxy/PointLight_HEA_ShipBeaconLower").gameObject.AddComponent<CustomPulsingLight>();
		newLowerPulsingLight._emissiveRenderer = lowerPulsingLight._emissiveRenderer;
		newLowerPulsingLight._materialIndex = lowerPulsingLight._materialIndex;
		newLowerPulsingLight._pulseRate = lowerPulsingLight._pulseRate;
		newLowerPulsingLight._intensityFluctuation = lowerPulsingLight._intensityFluctuation;
		newLowerPulsingLight._rangeFluctuation = lowerPulsingLight._rangeFluctuation;
		newLowerPulsingLight._timeOffset = lowerPulsingLight._timeOffset;
		newLowerPulsingLight._initLightIntensity = 0.5f;
		newLowerPulsingLight._initLightRange = 10;
		newLowerPulsingLight._initEmissionColor = new Color(1, 0.8496957f, 0.5808822f, 1);
		Destroy(lowerPulsingLight);

		remoteTransform.gameObject.SetActive(true);
		return remoteTransform;
	}
}
