using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabboniRoll : RabboniControl
{
    public Slider slider;
	
	void Start()
	{
		slider = GetComponent<Slider>();
	}
	
    public override void Sync(Vector3 val)
	{
		if(val.x < -4000f)
		{
			slider.value = Mathf.Lerp(0, 1f, (val.x+4000f)/-12000f  );
		}
		else if(val.x > 4000f)
		{
			slider.value = Mathf.Lerp(0, -1f, (val.x-4000f)/12000f  );
		}
		else
		{
			slider.value = 0f;
		}
		
	}
}
