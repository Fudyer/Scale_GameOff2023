using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public AudioClip clip;
	public List<AudioClip> clips = new	List<AudioClip>();
	public float distanceToTrigger = 1f;
	public bool triggered = false;
	public bool triggerAlways = false;
	public float scaleTrigger = 1f;
	bool canTrigger = true;
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
			AudioClip clipToPlay = null;
			if (!triggered && clip != null)
			{
    			clipToPlay = clip;
			}
			else
			{
    			clipToPlay = clips[Random.Range(0, clips.Count)];
			}
			triggered = true;
			GameJefe.Instance.PlayAudio(clipToPlay);
			canTrigger = false;
		}
			
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
			canTrigger = true;
	}
}
