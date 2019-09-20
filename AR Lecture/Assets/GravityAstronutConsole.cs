using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityAstronutConsole : MonoBehaviour
{
	public Transform astronutRef;
	public Transform launchRef;
	public GameObject astronutPrefab;
	
	public List<GameObject> astronutList;
	
	public float mass;
	public string massParam
	{
		get { return String.Empty; }
		set 
		{ 
			try
			{
				float massInput = float.Parse(value); 
				
				if(massInput > 0)
				{
					mass = massInput;
					massLog.text = String.Empty;
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
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void Launch()
	{
		GameObject astronut = (GameObject)Instantiate(astronutPrefab, launchRef.position, launchRef.rotation, astronutRef);
		astronut.SetActive(true);
		astronut.transform.localScale = astronutPrefab.transform.lossyScale;
		
		Rigidbody astronutRb = astronut.GetComponent<Rigidbody>();
		astronutRb.velocity = launchRef.forward * initVelocity;
		
		astronutList.Add(astronut);
	}
	
	
	public void ClearAllAstronuts()
	{
		for (int i=0; i< astronutList.Count; i++)
		{
			Destroy(astronutList[i].gameObject);
		}
		astronutList.Clear();
	}
}
