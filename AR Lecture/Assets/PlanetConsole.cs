using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetConsole : MonoBehaviour
{
	// public 
	public float planetRadius;
	
	public float sunFar;
	public float aAxis;
	public float bAxis;
	
	public Transform planet;
	public float rSpeed;  //radian / hour 
	
	public int orbitResolution;
	public LineRenderer orbit;
	
    // Start is called before the first frame update
    void Start()
    {
		Init();
        DrawObrit();
    }
	
	void Init()
	{
		planet.localScale = Vector3.one * planetRadius * SolarSysyemConsole.instance.planetSize;
	}

    // Update is called once per frame
    void Update()
    {
		Vector3 x = transform.right * (sunFar - aAxis + aAxis * Mathf.Cos(rSpeed * 24f * SolarSysyemConsole.instance.time) );
		Vector3 z = transform.forward * (bAxis * Mathf.Sin(rSpeed * 24f * SolarSysyemConsole.instance.time) );
		
        planet.localPosition = x + z;
		orbit.widthMultiplier = planet.lossyScale.x * SolarSysyemConsole.instance.obritWidth;
    }
	
	public void DrawObrit()
	{
		orbit.positionCount = orbitResolution + 1;
				
		float angleUnit = 360f/orbitResolution;
		// Debug.Log("angleUnit: " + angleUnit);

		for(int i = 0; i < orbitResolution + 1; i++)
		{
			Vector3 x = transform.right * (sunFar - aAxis + aAxis * Mathf.Cos(Mathf.Deg2Rad * angleUnit * i) );
			Vector3 z = transform.forward * (bAxis * Mathf.Sin(Mathf.Deg2Rad * angleUnit * i) );
			orbit.SetPosition(i, x+z );
		}		
	}
	
	
}
