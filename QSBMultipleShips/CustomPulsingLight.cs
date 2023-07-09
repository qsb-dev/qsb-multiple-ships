using UnityEngine;

namespace QSBMultipleShips;
internal class CustomPulsingLight : MonoBehaviour
{
	private static MaterialPropertyBlock s_matPropBlock;
	private static int s_propID_EmissionColor;
	private Light _light;

	public Renderer _emissiveRenderer;
	public int _materialIndex;
	public float _pulseRate = 1f;
	public float _intensityFluctuation;
	public float _rangeFluctuation;
	public float _timeOffset;

	public float _initLightIntensity;
	public float _initLightRange;
	public Color _initEmissionColor;

	private void Awake()
	{
		_light = GetComponent<Light>();
		if (s_matPropBlock == null)
		{
			s_matPropBlock = new MaterialPropertyBlock();
			s_propID_EmissionColor = Shader.PropertyToID("_EmissionColor");
		}
	}

	private void Update()
	{
		var num = Mathf.Sin((Time.time + _timeOffset) * _pulseRate);
		_light.intensity = num * _intensityFluctuation + _initLightIntensity;
		_light.range = num * _rangeFluctuation + _initLightRange;
		if (_emissiveRenderer != null)
		{
			var num2 = Mathf.Max(_light.intensity / _initLightIntensity, 0f);
			s_matPropBlock.SetColor(s_propID_EmissionColor, num2 * num2 * _initEmissionColor);
			_emissiveRenderer.SetPropertyBlock(s_matPropBlock);
		}
	}
}
