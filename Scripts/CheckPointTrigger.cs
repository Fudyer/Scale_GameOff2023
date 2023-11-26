using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTrigger : MonoBehaviour
{
	public bool canTrigger = true;
	public float distanceToTrigger = 1f;
	public bool triggered = false;
	public bool triggerAlways = false;
	public float scaleTrigger = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider other)
	{
		if(!canTrigger) return;
		if(scaleTrigger != GameJefe.Instance.levelScale) return;
		if(triggered && !triggerAlways) return;
		if (other.CompareTag("Player")) {
			CheckpointManager.Instance.SetCheckPointHere();
		}
			
	}
}
