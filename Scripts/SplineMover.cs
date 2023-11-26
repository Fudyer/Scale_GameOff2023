using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class SplineMover : MonoBehaviour
{
	public SWS.splineMove splineMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	[Button]
	public void DoMove() {
		splineMove.StartMove();
	}
}
