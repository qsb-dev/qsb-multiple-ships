using OWML.ModHelper;
using QSB;
using QSB.Utility;
using QSBMultipleShips.TransformSyncs;
using UnityEngine;

namespace QSBMultipleShips;

public class Core : ModBehaviour
{
	public static Core Instance { get; private set; }

	public GameObject CockpitPrefab { get; private set; }
	public GameObject CabinPrefab { get; private set; }
	public GameObject SuppliesPrefab { get; private set; }
	public GameObject EnginePrefab { get; private set; }
	public GameObject FrontLandingPrefab { get; private set; }
	public GameObject LeftLandingPrefab { get; private set; }
	public GameObject RightLandingPrefab { get; private set; }

	public void Awake()
	{
		Instance = this;
	}

	public void Start()
	{
		CockpitPrefab = QSBNetworkManager.MakeNewNetworkObject("NetworkShip_Cockpit", typeof(ShipCockpitTransformSync));
		QSBNetworkManager.singleton.spawnPrefabs.Add(CockpitPrefab);

		CabinPrefab = QSBNetworkManager.MakeNewNetworkObject("NetworkShip_Cabin", typeof(ShipCabinTransformSync));
		QSBNetworkManager.singleton.spawnPrefabs.Add(CabinPrefab);

		FrontLandingPrefab = QSBNetworkManager.MakeNewNetworkObject("NetworkShip_FrontLanding", typeof(ShipFrontLandingGearTransformSync));
		QSBNetworkManager.singleton.spawnPrefabs.Add(FrontLandingPrefab);

		LeftLandingPrefab = QSBNetworkManager.MakeNewNetworkObject("NetworkShip_LeftLanding", typeof(ShipLeftLandingGearTransformSync));
		QSBNetworkManager.singleton.spawnPrefabs.Add(LeftLandingPrefab);

		RightLandingPrefab = QSBNetworkManager.MakeNewNetworkObject("NetworkShip_RightLanding", typeof(ShipRightLandingGearTransformSync));
		QSBNetworkManager.singleton.spawnPrefabs.Add(RightLandingPrefab);

		SuppliesPrefab = QSBNetworkManager.MakeNewNetworkObject("NetworkShip_Supplies", typeof(ShipSuppliesTransformSync));
		QSBNetworkManager.singleton.spawnPrefabs.Add(SuppliesPrefab);

		EnginePrefab = QSBNetworkManager.MakeNewNetworkObject("NetworkShip_Engine", typeof(ShipEngineTransformSync));
		QSBNetworkManager.singleton.spawnPrefabs.Add(EnginePrefab);
	}
}
