using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFinder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SLAMConsole.instance)
		{
			SLAMConsole.instance.planePosition = transform.position;
			SLAMConsole.instance.planeRotation = transform.rotation;
		}
    }
}
