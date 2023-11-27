using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
public class EndBox : MonoBehaviour
{
	public bool triggered = false;
	public bool triggerAlways = false;
	public float scaleTrigger = 1f;
	
	bool canTrigger = true;
	public bool inRange = false;
	bool seen = false;
	bool taken = false;
	public AudioClip seenClip;
	public AudioClip notEnoughKeysClip;
	public AudioClip enoughKeysClip;
	public Transform lidTransform;
	public Transform figureTransform;
	public Transform crankTransform;
	public float crankRotationSpeed = 5f;
	public float figureRotationSpeed = 2f;
	public float lidOpenX;
	public float figureOpenY;
	public float figureRaiseSpeed;
	public float lidRaiseSpeed;
	public float endDelay =1f;
	// Start is called before the first frame update
	void Start()
	{

	}
	public static float Clamp0360(float eulerAngles)
	{
		float result = eulerAngles - Mathf.CeilToInt(eulerAngles / 360f) * 360f;
		if (result < 0)
		{
			result += 360f;
		}
		return result;
	}
	// Update is called every frame, if the MonoBehaviour is enabled.
	protected void Update()
	{
		if(!taken) return;
		crankTransform.Rotate(Vector3.right * crankRotationSpeed * Time.deltaTime);
		figureTransform.Rotate(Vector3.up * figureRotationSpeed * Time.deltaTime);
	}
	private void OnTriggerEnter(Collider other)
	{
		if(!canTrigger) return;
		//if(scaleTrigger != GameJefe.Instance.levelScale) return;
		//if(triggered && !triggerAlways) return;
		if (other.CompareTag("Player")) {
			if(!seen) {
				seen = true;
				GameJefe.Instance.PlayAudio(seenClip);
			}
			inRange = true;
			triggered = true;
		}
			
	}
	private void OnTriggerExit(Collider other)
	{
		inRange = false;
	}
	[Button]
	public void OnInteract() {
		if(taken) return;
		if(!inRange) return;
		if(GameJefe.Instance.numbKeys < 5) {
			GameJefe.Instance.PlayAudio(notEnoughKeysClip);
			return;
		}
		taken = true;
		GameJefe.Instance.PlayAudio(enoughKeysClip);
		Sequence sequence = DOTween.Sequence();
		sequence.Join(lidTransform.DOLocalRotate(new Vector3(lidOpenX,0f,0f),lidRaiseSpeed));
		sequence.Join(figureTransform.DOLocalMove(new	Vector3(0.0f,figureOpenY,0f),figureRaiseSpeed));
		sequence.AppendInterval(endDelay);
		sequence.AppendCallback(() => {
			GameJefe.Instance.EndGame();
		});
	}
}
