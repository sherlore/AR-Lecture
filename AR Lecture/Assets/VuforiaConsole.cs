using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VuforiaConsole : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SetAR(bool useAR)
	{
		if(useAR)
		{
			MixedRealityController.Instance.SetMode(MixedRealityController.Mode.HANDHELD_AR_DEVICETRACKER);
		}
		else
		{
			MixedRealityController.Instance.SetMode(MixedRealityController.Mode.HANDHELD_VR);
		}
	}
}
