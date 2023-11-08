using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
	public float baseIntensity = 1.0f;
	public float minFlickerDelay = 0.1f;
	public float maxFlickerDelay = 1.0f;
	public float minIntensity = 0.5f;
	public float maxIntensity = 1.5f;

	public bool isFlickering = true;
	private float nextFlickerTime;
	private float flickerDuration = 0.1f;
	public float currentIntensity;
	private MaterialPropertyBlock materialProperties;
	public Renderer renderer;
	public Color originalEmissionColor = Color.red;
	public Color minEmissionColor = Color.black;
	public Color newEmissionColor = Color.black;
	private void Start()
	{
		
		nextFlickerTime = Time.time + Random.Range(minFlickerDelay, maxFlickerDelay);
		materialProperties = new MaterialPropertyBlock();
		renderer = GetComponent<Renderer>();
		originalEmissionColor = renderer.sharedMaterial.GetColor("_EmissionColor");
	}

	private void Update()
	{
		if (Time.time >= nextFlickerTime & isFlickering)
		{
			
			// Flicker the light
			StartCoroutine(FlickerLight());

			// Set the time for the next flicker
			nextFlickerTime = Time.time + Random.Range(minFlickerDelay, maxFlickerDelay);
			
			
		}
		// Calculate the emission color based on intensity
		newEmissionColor = Color.Lerp( minEmissionColor, originalEmissionColor, Mathf.InverseLerp(minIntensity, maxIntensity, currentIntensity));
		materialProperties.SetColor("_EmissionColor", newEmissionColor);
		renderer.SetPropertyBlock(materialProperties);
	}

	private IEnumerator FlickerLight()
	{
		float originalIntensity = currentIntensity;

		// Randomly adjust intensity for a short duration
		for (float t = 0; t < flickerDuration; t += Time.deltaTime)
		{
			float lerpValue = Mathf.PingPong(Time.time * 10.0f, 1.0f); // Create a ping-pong effect
			float intensity = Mathf.Lerp(originalIntensity, Random.Range(minIntensity, maxIntensity), lerpValue);
			currentIntensity = intensity;
			yield return null;
		}

		// Restore the original intensity
		currentIntensity = baseIntensity;
	}
}
