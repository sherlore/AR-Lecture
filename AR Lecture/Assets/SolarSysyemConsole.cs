using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSysyemConsole : MonoBehaviour
{
	public static SolarSysyemConsole instance;
	public float simulationSpeed = 1f;  //1sec = 1day
	public float simulationSpeedRatio = 86400f;  //1sec = 1day
	public float planetSize = 0.001f;
	public float obritWidth = 0.5f;
	public float time;
	// public float realtime;
	
	
	void Awake()
	{
		instance = this;
	}
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * simulationSpeed;
		// realtime = Time.time;
    }
	
	
	public void FixSimulationSpeed(float val)
	{
		// Debug.Log("FixSimulationSpeed: " + val);
		
		simulationSpeed = val/simulationSpeedRatio;
	}
}
