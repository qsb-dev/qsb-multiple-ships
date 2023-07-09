using UnityEngine;

namespace QSBMultipleShips;
public class CustomHatchController : MonoBehaviour
{
	public Transform _hatch;

	private bool _hatchOpening;
	private bool _hatchClosing;
	private float _timeSinceRotation;
	private Quaternion _hatchClosedQuaternion;
	private Quaternion _hatchOpenedQuaternion;

	private void Awake()
	{
		_hatchClosedQuaternion = Quaternion.Euler(new Vector3(180, 0, 0));
		_hatchOpenedQuaternion = Quaternion.Euler(new Vector3(0, 0, 0));
		enabled = false;
	}

	private void FixedUpdate()
	{
		if (_hatchOpening && _hatch.localRotation != _hatchOpenedQuaternion)
		{
			if (_timeSinceRotation == 0.5f)
			{
				_timeSinceRotation = 0f;
			}

			_hatch.localRotation = Quaternion.Lerp(_hatchClosedQuaternion, _hatchOpenedQuaternion, _timeSinceRotation / 0.5f);
			_timeSinceRotation += Time.deltaTime;
			if (_timeSinceRotation >= 0.5f)
			{
				_hatch.localRotation = _hatchOpenedQuaternion;
				_timeSinceRotation = 0.5f;
				_hatchOpening = false;
				enabled = false;
				return;
			}
		}
		else if (_hatchClosing && _hatch.localRotation != _hatchClosedQuaternion)
		{
			if (_timeSinceRotation == 0.5f)
			{
				_timeSinceRotation = 0f;
			}

			_hatch.localRotation = Quaternion.Lerp(_hatchOpenedQuaternion, _hatchClosedQuaternion, _timeSinceRotation / 0.5f);
			_timeSinceRotation += Time.deltaTime;
			if (_timeSinceRotation >= 0.5f)
			{
				_hatch.localRotation = _hatchClosedQuaternion;
				_timeSinceRotation = 0.5f;
				_hatchClosing = false;
				enabled = false;
			}
		}
	}

	public void OpenHatch()
	{
		/*if (this._shipAudioController == null)
		{
			this._shipAudioController = Locator.GetShipTransform().GetComponentInChildren<ShipAudioController>();
		}
		this._shipAudioController.PlayOpenHatch();*/
		enabled = true;
		_hatchOpening = true;
		_hatchClosing = false;
	}

	public void CloseHatch()
	{
		/*if (this._shipAudioController == null)
		{
			this._shipAudioController = Locator.GetShipTransform().GetComponentInChildren<ShipAudioController>();
		}
		this._shipAudioController.PlayCloseHatch();*/
		enabled = true;
		_hatchClosing = true;
		_hatchOpening = false;
	}
}
