using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteConsole : MonoBehaviour
{
    // public 
	public float planetRadius;
	
	public float sunFar;
	public float aAxis;
	public float bAxis;
	
	public Transform planet;
	public float rSpeed;  //radian / hour 
	
	public Transform center;
	
    // Start is called before the first frame update
    void Start()
    {
		Init();
    }
	
	void Init()
	{
		RefreshScale();
	}
	
	public void RefreshScale()
	{
		planet.parent = center.parent;
		planet.localScale = Vector3.one * planetRadius * SolarSysyemConsole.instance.planetSize;
		planet.parent = transform;
	}

    // Update is called once per frame
    void Update()
    {
		Vector3 x = Vector3.right * (sunFar - aAxis + aAxis * Mathf.Cos(rSpeed * 24f * SolarSysyemConsole.instance.time) );
		Vector3 z = Vector3.forward * (bAxis * Mathf.Sin(rSpeed * 24f * SolarSysyemConsole.instance.time) );
		
        planet.localPosition = x + z;
		planet.localPosition /= center.localScale.x;
    }
	
}
