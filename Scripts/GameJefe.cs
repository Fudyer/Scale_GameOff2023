using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameJefe : MonoBehaviour
{
	public static GameJefe Instance { get; private set;}
	public AudioSource characterAudioSource;
	public Transform characterTransform;
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
        
    }
}
