using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class OpenDoor : MonoBehaviour
{
	public bool triggerAlways = true;
	public bool triggered = false;
	public float scaleTrigger = 1f;
	bool canTrigger = true;
	bool inRange = false;
	public float yRotValue = 90f;
	public Transform targetTransform;
	public float openSpeed = 1f;
	bool	opened = false;
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
		if(opened) return;
		if(!inRange) return;
		opened = true;
		Vector3 newRotation = new	Vector3(targetTransform.localRotation.x, yRotValue, targetTransform.localRotation.z);
		targetTransform.DOLocalRotate(newRotation,openSpeed);
	}
}
