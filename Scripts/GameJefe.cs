using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;
public class GameJefe : MonoBehaviour
{
	public static GameJefe Instance { get; private set;}
	public AudioSource characterAudioSource;
	public Transform characterTransform;
	public Transform levelTransform;
	public Transform playerPositionMarker;
	public float levelScale =1f;
	bool isScaling = false;
	
    // Start is called before the first frame update
    void Start()
    {
	    if(Instance == null) {
	    	Instance = this;
	    }        
    }

    // Update is called once per frame
    void Update()
    {
	    if(isScaling) {
	    	levelTransform.localScale = new	Vector3(levelScale, levelScale, levelScale);
	    	characterTransform.position = playerPositionMarker.position;
	    }
    }
	public void PlayAudio(AudioClip clip) {
		characterAudioSource.clip = clip;
		characterAudioSource.Play();
	}
	[Button]
	public void Scale(float scaleSize, float time, Ease ease, AudioClip clip = null) {
		playerPositionMarker.position = characterTransform.position;
		isScaling = true;
		DOTween.To(() => levelScale, x => levelScale = x, scaleSize,time).SetEase(ease).OnComplete(() => { 
			isScaling = false; 
			if(clip) {
				PlayAudio(clip);
			}
		});
	}
	[Button]
	public void SetTimeScale(float timeScale = 1f) {
		Time.timeScale = timeScale;
	}
}
