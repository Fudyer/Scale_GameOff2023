using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiasGames.Components;
public class CharacterControllerUtilities : MonoBehaviour
{
	public ICapsule capsule;
    // Start is called before the first frame update
    void Start()
    {
	    capsule = GetComponent<ICapsule>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
