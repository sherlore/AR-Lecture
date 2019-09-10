using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{	
	public float planetRadius;
	public float sunSize;
	
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void Init()
	{
		RefreshScale();
	}
	
	public void RefreshScale()
	{
		transform.localScale = Vector3.one * planetRadius * SolarSysyemConsole.instance.planetSize * sunSize;
	}
	
	public void SetSunSize(float val)
	{
		sunSize = val;
	}
}
