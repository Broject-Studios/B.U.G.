using UnityEngine;
using System.Collections;

/**
* ...
* @author Niek Schoone
**/

public class CameraShake : MonoBehaviour
{
	private Vector3 originPosition;
	private Quaternion originRotation;

	public float shakeDecay;
	public float shakeIntensity;

	private bool shaking;

	private Transform _transform;

	void OnEnable()
	{
		_transform = transform;
	}

	void Update()
	{
		if (!shaking)
		{
			return;
		}
		if (shakeIntensity > 0f)
		{
			_transform.localPosition = originPosition + Random.insideUnitSphere * shakeIntensity;

			_transform.localRotation = new Quaternion(
				originRotation.x + Random.Range(-shakeIntensity, shakeIntensity),
				originRotation.y + Random.Range(-shakeIntensity, shakeIntensity),
				originRotation.z + Random.Range(-shakeIntensity, shakeIntensity),
				originRotation.w + Random.Range(-shakeIntensity, shakeIntensity));

			shakeIntensity -= shakeDecay;
		}
		else
		{
			shaking = false;
			_transform.localPosition = originPosition;
			_transform.localRotation = originRotation;
		}
	}

	public void Shake(float givenIntensity, float givenDecay)
	{
		if (!shaking)
		{
			originPosition = _transform.localPosition;
			originRotation = _transform.localRotation;
		}
		shaking = true;
		shakeIntensity = givenIntensity;
		shakeDecay = givenDecay;
	}
}