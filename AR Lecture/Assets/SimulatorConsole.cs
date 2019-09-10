using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulatorConsole : MonoBehaviour
{
	public static SimulatorConsole instance;	
	public float simulationSpeed;
	public float simulationSpeedRatio = 3600f;  //1sec = 1hour
	public float time;
	public float maximumTime;
	public Slider timeSlider;
	public bool isManualTime;
	
	public bool isPause;
	
    // Start is called before the first frame update
    void Awake()
    {
        SimulatorConsole.instance = this;
    }
	
    // Start is called before the first frame update
    void Start()
    {
		maximumTime = 365.256f * 24f - 1f;
		timeSlider.maxValue = maximumTime;
    }

    // Update is called once per frame
    void Update()
    {
		if(isManualTime || isPause) return;
		
        time += Time.deltaTime * simulationSpeed;
		if(time > maximumTime)
		{
			time = 0f;
		}
		timeSlider.value = time;
    }
	
	public void SetTime(float val)
	{
		time = val;
	}
	
	public void JumpTime(float val)
	{
		time += val;
		if(time > maximumTime)
		{
			time -= maximumTime;
		}
		else if(time < 0)
		{
			time += maximumTime;
		}
		timeSlider.value = time;
	}
	
	public void SetPause(bool val)
	{
		isPause = val;
	}
	
	public void TimeSliderManual(bool isManual)
	{
		isManualTime = isManual;
	}
	
	public void SetSimulationSpeed(float val)
	{
		simulationSpeed = val/simulationSpeedRatio;
		// simulationSpeedText.text = string.Format("模擬速度: {0}倍", val);
	}
}
