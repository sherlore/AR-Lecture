using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
	public float dayPerCycle; 
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * -1f * 360/dayPerCycle * Time.deltaTime * SolarSysyemConsole.instance.simulationSpeed);
    }
}
