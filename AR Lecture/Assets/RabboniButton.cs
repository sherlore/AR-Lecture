using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabboniButton : RabboniControl
{
    public Button button;
	public bool positiveInvoke = false;
	public bool invoked = false;
	
	void Start()
	{
		button = GetComponent<Button>();
	}
	
    public override void Sync(Vector3 val)
	{
		if(val.z > 8000f )
		{
			if(positiveInvoke)
			{
				if(!invoked)
				{
					invoked = true;
					button.onClick.Invoke();
				}
			}
			else
			{
				invoked = false;
			}
		}
		else if(val.z < -8000f)
		{
			if(!positiveInvoke)
			{
				if(!invoked)
				{
					invoked = true;
					button.onClick.Invoke();
				}
			}
			else
			{
				invoked = false;
			}
		}
		
	}
}
