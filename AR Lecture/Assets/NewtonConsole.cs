using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewtonConsole : MonoBehaviour
{
	public static NewtonConsole instance;
	
	public GameObject rocketStartPointPrefab;
	public GameObject rocketPrefab;
	public Transform launchRef;
	
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
	
	public float burstForce;
	public string burstForceParam
	{
		get { return String.Empty; }
		set 
		{ 
			try
			{
				burstForce = float.Parse(value); 
				burstForceLog.text = String.Empty;
			}
			catch (Exception e)
			{
				burstForceLog.text = "*錯誤，非數字輸入";
			} 
			predictAcc.text = String.Format("{0:F2}", burstForce/mass);
		}
	}
	public Text burstForceLog;
		
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
					predictAcc.text = String.Format("{0:F2} M/S^2", burstForce/mass);
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
	
	public float limitedTime;
	public string limitedTimeParam
	{
		get { return String.Empty; }
		set 
		{ 
			try
			{
				limitedTime = float.Parse(value); 
				limitedTimeLog.text = String.Empty;
			}
			catch (Exception e)
			{
				limitedTimeLog.text = "*錯誤，非數字輸入";
			} 
		}
	}
	public Text limitedTimeLog;
	
	public float limitedDistance;
	public string limitedDistanceParam
	{
		get { return String.Empty; }
		set 
		{ 
			try
			{
				limitedDistance = float.Parse(value); 
				limitedDistanceLog.text = String.Empty;
			}
			catch (Exception e)
			{
				limitedDistanceLog.text = "*錯誤，非數字輸入";
			} 
		}
	}
	public Text limitedDistanceLog;
	
	public float dotPeriod;
	public string dotPeriodParam
	{
		get { return String.Empty; }
		set 
		{ 
			try
			{
				dotPeriod = float.Parse(value); 
				dotPeriodLog.text = String.Empty;
			}
			catch (Exception e)
			{
				dotPeriodLog.text = "*錯誤，非數字輸入";
			} 
		}
	}
	public Text dotPeriodLog;
	
    void Awake()
    {
        NewtonConsole.instance = this;
    }
	
    // Start is called before the first frame update
    void Start()
    {
        // LaunchRockt();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void LaunchRockt()
	{
		
		GameObject rocketStartPoint = (GameObject)Instantiate(rocketStartPointPrefab, launchRef.position, launchRef.rotation);
		rocketStartPoint.transform.localScale = launchRef.lossyScale;
		NewStartPoint rocketStartPointInfo = rocketStartPoint.GetComponent<NewStartPoint>();
		rocketStartPointInfo.burstForceInfo.text = String.Format("推進力: {0}", burstForce);
		rocketStartPointInfo.massInfo.text = String.Format("火箭質量: {0}", mass);
		rocketStartPointInfo.InitvelocityInfo.text = String.Format("初始速度: {0}", initVelocity);
		
		GameObject rocket = (GameObject)Instantiate(rocketPrefab, launchRef.position, launchRef.rotation, rocketStartPoint.transform);
		rocket.transform.localScale = Vector3.one;
		NewtonRocket rocketInfo = rocket.GetComponent<NewtonRocket>();
		
		rocketInfo.initVelocity = initVelocity;
		rocketInfo.burstForce = burstForce;
		rocketInfo.limitedTime = limitedTime;
		rocketInfo.limitedDistance = limitedDistance;
		rocketInfo.dotPeriod = dotPeriod;
		// rocketInfo.rb.mass = mass;
		rocketInfo.mass = mass;
		rocketInfo.FixedTimeLaunch();
	}
}
