using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabboniToggle : RabboniControl
{
    public Toggle toggle;
	
	void Start()
	{
		toggle = GetComponent<Toggle>();
	}
	
    public override void Sync(Vector3 val)
	{
		if(val.z > 8000f)
		{
			if(!toggle.isOn)
			{
				toggle.isOn = true;
			}
		}
		else if(val.z < -8000f)
		{
			if(toggle.isOn)
			{
				toggle.isOn = false;
			}
		}
		
	}
}
