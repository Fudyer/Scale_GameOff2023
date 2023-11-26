using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
	public bool triggered = false;
	public bool triggerAlways = false;
	public float scaleTrigger = 1f;
	
	bool canTrigger = true;
	bool inRange = false;
	public Transform keyTransform;
	public Transform rewardTransform;
	bool seen = false;
	bool taken = false;
	// Start is called before the first frame update
	void Start()
	{

	}
	private void OnTriggerEnter(Collider other)
	{
		if(!canTrigger) return;
		if(scaleTrigger != GameJefe.Instance.levelScale) return;
		if(triggered && !triggerAlways) return;
		if (other.CompareTag("Player")) {
			if(!seen) {
				seen = true;
				GameJefe.Instance.SeeKey();
			}
			inRange = true;
			triggered = true;
		}
			
	}
	private void OnTriggerExit(Collider other)
	{
		inRange = false;
	}
	public void OnInteract() {
		if(taken) return;
		if(!inRange) return;
		taken = true;
		GameJefe.Instance.numbKeys++;
		Destroy(keyTransform.gameObject);
		rewardTransform.gameObject.active = true;
		
	}
}
