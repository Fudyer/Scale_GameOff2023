using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public AudioClip clip;
	public float distanceToTrigger = 1f;
	public bool triggered = false;
	
    // Start is called before the first frame update
    void Start()
    {

    }
	
    // Update is called once per frame
    void Update()
	{
		if(triggered) return;
		float distance = Vector3.Distance(this.transform.position, GameJefe.Instance.characterTransform.position);
		if(distance <= distanceToTrigger) {
			triggered = true;
			
			GameJefe.Instance.characterAudioSource.clip = clip;
			GameJefe.Instance.characterAudioSource.Play();
		}
	}
	// Implement OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn.
	protected void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position,distanceToTrigger);
	}
}
