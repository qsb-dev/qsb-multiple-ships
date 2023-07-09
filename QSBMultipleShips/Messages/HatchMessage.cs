using QSB.Messaging;
using QSB.Player;
using QSBMultipleShips.TransformSyncs;

namespace QSBMultipleShips.Messages;
internal class HatchMessage : QSBMessage<bool>
{
	public HatchMessage(bool open) : base(open) { }

	public override void OnReceiveRemote()
	{
		var cabin = QSBPlayerManager.GetPlayer(From).GetCustomData<ShipCabinTransformSync>("Cabin");

		if (cabin == null)
		{
			return;
		}

		if (Data)
		{
			cabin.Hatch.OpenHatch();
		}
		else
		{
			cabin.Hatch.CloseHatch();
		}
	}
}
