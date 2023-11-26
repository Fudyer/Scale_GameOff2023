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
	public Transform checkpointPositionMarker;
	public float levelScale =1f;
	bool isScaling = false;
	public AudioClip initialDialogue;
	public CameraFadePackTransition transition;
	public bool initiated = false;
	public TextRevealer revealer;
	public TMPro.TextMeshProUGUI revealerText;
	public bool skipRequested = false;
	public bool skipNotified = false;
	int keyFound = 0;
	public List<AudioClip> keyfoundClips;
	public int numbKeys = 0;
	public AudioClip endGameClip;
	public CameraFadePackTransition endTransition;
    // Start is called before the first frame update
    void Start()
    {
	    if(Instance == null) {
	    	Instance = this;
	    	//SetTimeScale(0f);
	    	PlayAudio(initialDialogue);
	    	playerPositionMarker.position = characterTransform.position;
	    }        
    }
	[Button]
	public void EndGame() {
		PlayAudio(endGameClip);
		endTransition.enabled = true;
		endTransition.fadeOut();
	}
    // Update is called once per frame
    void Update()
	{
		if(!initiated) {
			characterTransform.position = playerPositionMarker.position;
			if(characterAudioSource.isPlaying && !skipRequested) return;
			initiated = true;
			transition.fadeIn();
			//SetTimeScale(1f);
			return;
		}
	    if(isScaling) {
	    	levelTransform.localScale = new	Vector3(levelScale, levelScale, levelScale);
	    	characterTransform.position = playerPositionMarker.position;
	    }
    }
	public void PlayAudio(AudioClip clip) {
		characterAudioSource.clip = clip;
		characterAudioSource.Play();
	}
	public void SeeKey() {
		PlayAudio(keyfoundClips[keyFound]);
		keyFound++;
	}
	[Button]
	public void QuitGame() {
		Debug.Log("Quiting Process Started");
		Application.Quit();
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
