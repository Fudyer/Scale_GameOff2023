using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTrigger : MonoBehaviour
{
	public AudioClip clip = null;
	public bool triggered = false;
	public bool triggerAlways = false;
	public float scaleTrigger = 1f;
	public float scaleToSet = 3f;
	public float scaleTime = 3f;
	public DG.Tweening.Ease scaleEase;
	
	bool canTrigger = true;
	bool inRange = false;
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
			inRange = true;
			triggered = true;
		}
			
	}
	private void OnTriggerExit(Collider other)
	{
		inRange = false;
	}
	public void OnInteract() {
		if(!inRange) return;
		GameJefe.Instance.Scale(scaleToSet,scaleTime,scaleEase,clip);
	}
}
