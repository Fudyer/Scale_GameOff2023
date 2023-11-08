using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLightSource : MonoBehaviour
{
	public List<Light> lights = new	List<Light>();
	public FlickeringLight flickeringLightBase;
    // Update is called once per frame
    void Update()
    {
	    foreach(Light light in lights) {
	    	light.intensity = flickeringLightBase.currentIntensity;
	    } 
    }
}
