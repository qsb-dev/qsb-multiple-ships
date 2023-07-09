using QSB.Messaging;
using QSB.Player;
using QSB.Utility;
using QSBMultipleShips.TransformSyncs;

namespace QSBMultipleShips.Messages;
internal class HeadlightMessage : QSBMessage<bool>
{
	public HeadlightMessage(bool on) : base(on) { }

	public override void OnReceiveRemote()
	{
		var landingGear = QSBPlayerManager.GetPlayer(From).GetCustomData<ShipFrontLandingGearTransformSync>("FrontLandingGear");

		if (landingGear == null)
		{
			return;
		}

		DebugLog.DebugWrite($"headlight SetOn {Data}");
		var shipLight = landingGear.Headlight; 
		shipLight.SetOn(Data);
	}
}
