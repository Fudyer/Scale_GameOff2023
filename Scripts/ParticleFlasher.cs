using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFlasher : MonoBehaviour
{
	public List<ParticleSystem> particleSystems = new List<ParticleSystem>();
	public Vector2 delayMinMax;
	bool triggered = false;
	float triggerTime = 0f;
	float timer = 0f;
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		timer += Time.deltaTime;
		if(triggered) {
			triggered = !triggered;
			timer = 0f;
			triggerTime = Random.Range(delayMinMax.x,delayMinMax.y);
			TriggerParticles();
		} else if(timer > triggerTime) {
			triggered = true;
		}
		
		
	}
	// Function to trigger all the particle systems in the list
	public void TriggerParticles()
	{
		foreach (ParticleSystem ps in particleSystems)
		{
			ps.Play();
		}
	}
}
