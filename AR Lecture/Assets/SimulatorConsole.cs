using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulatorConsole : MonoBehaviour
{
	public static SimulatorConsole instance;	
	public float simulationSpeed;
	public Text simulationSpeedText;
	
    // Start is called before the first frame update
    void Start()
    {
        SimulatorConsole.instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SetSimulationSpeed(float val)
	{
		simulationSpeed = val;
		simulationSpeedText.text = string.Format("模擬速度: {0}", val);
	}
}
