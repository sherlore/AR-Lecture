using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RabboniSlider : RabboniControl
{
    public Slider slider;
	private float myScaler;
	private float sliderVal;
	
	void Start()
	{
		slider = GetComponent<Slider>();
		myScaler = slider.maxValue - slider.minValue;
		myScaler *= 0.33f;
	}
	
	void Update()
	{
		slider.value += sliderVal * Time.deltaTime;
	}
	
    public override void Sync(Vector3 val)
	{
		if(val.x < -4000f)
		{
			sliderVal = Mathf.Lerp(0, myScaler, (val.x+4000f)/-12000f  );
		}
		else if(val.x > 4000f)
		{
			sliderVal = Mathf.Lerp(0, -myScaler, (val.x-4000f)/12000f  );
		}
		else
		{
			sliderVal = 0f;
		}
		
	}
}
