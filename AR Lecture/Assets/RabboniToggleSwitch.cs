using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabboniToggleSwitch : RabboniControl
{
    public Button buttonOn;
    public Button buttonOff;
	
	
    public override void Sync(Vector3 val)
	{
		if(val.z > 8000f)
		{
			if(buttonOn.gameObject.activeInHierarchy)
			{
				buttonOn.onClick.Invoke();
			}
		}
		else if(val.z < -8000f)
		{
			if(buttonOff.gameObject.activeInHierarchy)
			{
				buttonOff.onClick.Invoke();
			}
		}
		
	}
}
