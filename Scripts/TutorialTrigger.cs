using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
	public GameObject targetTutorial;
	public float scaleTrigger = 1f;
	public bool triggerAlways = false;
	bool triggered = false;
	private void Awake()
	{
		targetTutorial.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(scaleTrigger != GameJefe.Instance.levelScale) return;
		if(triggered && !triggerAlways) return;
		if (other.CompareTag("Player")) {
			targetTutorial.SetActive(true);
			triggered = true;
		}
			
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
			targetTutorial.SetActive(false);
	}
}
