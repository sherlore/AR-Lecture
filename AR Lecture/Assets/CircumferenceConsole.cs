using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircumferenceConsole : MonoBehaviour
{
	public Transform satelliteGroup;
	public Transform launchRef;
	public GameObject satellitePrefab;
	
	public float initVelocity;
	public string initVelocityParam
	{
		get { return String.Empty; }
		set 
		{ 
			try
			{
				initVelocity = float.Parse(value); 
				initVelocityLog.text = String.Empty;
			}
			catch (Exception e)
			{
				initVelocityLog.text = "*錯誤，非數字輸入";
			}
		}
	}
	public Text initVelocityLog;
	public InputField initVelocityInput;
	
	public float centripetalForce;
	public string centripetalForceParam
	{
		get { return String.Empty; }
		set 
		{ 
			try
			{
				centripetalForce = float.Parse(value); 
				centripetalForceLog.text = String.Empty;
			}
			catch (Exception e)
			{
				centripetalForceLog.text = "*錯誤，非數字輸入";
			} 
			predictAcc.text = String.Format("{0:F2} M/S^2", centripetalForce/mass);
		}
	}
	public Text centripetalForceLog;
	public InputField centripetalForceInput;
		
	public float mass;
	public string massParam
	{
		get { return String.Empty; }
		set 
		{ 
			mass = float.Parse(value); 
			try
			{
				float massInput = float.Parse(value); 
				
				if(massInput > 0)
				{
					mass = massInput;
					massLog.text = String.Empty;
					predictAcc.text = String.Format("{0:F2} M/S^2", centripetalForce/mass);
				}
				else
				{
					massLog.text = "*錯誤，質量必須大於0";
				}
			
				
			}
			catch (Exception e)
			{
				massLog.text = "*錯誤，非數字輸入";
			} 
		}
	}
	public Text massLog;
	
	public Text predictAcc;
	public Text distanceInfo;
	
    // Start is called before the first frame update
    void Start()
    {
        UpdateDistanceInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void ClearAllSatellite()
	{
		foreach (Transform child in satelliteGroup)
		{
			Destroy(child.gameObject);
		}
	}
	
	public void UpdateDistanceInfo()
	{
		distanceInfo.text = String.Format("{0:F3} M", Vector3.Distance(launchRef.position, CentripetalCenter.instance.transform.position));
	}
	
	public void SetCircumferenceCentripetalForceFromInitVelocity()
	{
		centripetalForce = GetCircumferenceCentripetalForceFromInitVelocity();
		centripetalForceInput.text = String.Format("{0}", centripetalForce );
		predictAcc.text = String.Format("{0:F2} M/S^2", centripetalForce/mass);
	}
	
	public void SetCircumferenceInitVelocityFromCentripetalForce()
	{
		initVelocity = GetCircumferenceInitVelocityFromCentripetalForce();
		initVelocityInput.text = String.Format("{0}", initVelocity );
	}
	
	public float GetCircumferenceCentripetalForceFromInitVelocity()
	{
		return mass * initVelocity * initVelocity / Vector3.Distance(launchRef.position, CentripetalCenter.instance.transform.position);
	}
	
	public float GetCircumferenceInitVelocityFromCentripetalForce()
	{
		float acc = centripetalForce/mass;
		return Mathf.Sqrt(acc * Vector3.Distance(launchRef.position, CentripetalCenter.instance.transform.position) );
	}
	
	public void Launch()
	{
		GameObject satellite = (GameObject)Instantiate(satellitePrefab, launchRef.position, launchRef.rotation, satelliteGroup);
		satellite.SetActive(true);
		satellite.transform.localScale = satellitePrefab.transform.lossyScale;
		
		SatelliteSimple satelliteInfo = satellite.GetComponent<SatelliteSimple>();
		satelliteInfo.initVelocity = initVelocity;
		satelliteInfo.acc = centripetalForce/mass;
		satelliteInfo.Launch();
	}
}
