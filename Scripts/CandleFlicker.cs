using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CandleFlicker : MonoBehaviour
{
	public Vector2 xTravelMinMax;
	public Vector2 yTravelMinMax;
	public Vector2 zTravelMinMax;
	public Vector2 travelTimeMinMax;
	public Vector2 lightIntensityMinMax;
	public Light flameLight;
	public Ease ease =	Ease.InOutBounce;
	float lightIntensity = 1f;
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		DoFlicker();
	}
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		flameLight.intensity = lightIntensity;
	}
	public void DoFlicker() {
		float travelTime = Random.Range(travelTimeMinMax.x, travelTimeMinMax.y);
		float xCord = Random.Range(xTravelMinMax.x, xTravelMinMax.y);
		float yCord = Random.Range(yTravelMinMax.x, yTravelMinMax.y);
		float zCord = Random.Range(zTravelMinMax.x, zTravelMinMax.y);
		Vector3 newVector = new	 Vector3(xCord,yCord,zCord);
		Transform flameTransform = flameLight.transform;
		float newIntensity = Random.Range(lightIntensityMinMax.x, lightIntensityMinMax.y);
		Sequence sequence = DOTween.Sequence();
		sequence.Join(flameTransform.DOLocalMove(newVector,travelTime).SetEase(ease));
		sequence.Join(DOTween.To(()=> lightIntensity, x => lightIntensity = x, newIntensity,travelTime).SetEase(ease));
		sequence.OnComplete(() => {DoFlicker();});
	}
}
