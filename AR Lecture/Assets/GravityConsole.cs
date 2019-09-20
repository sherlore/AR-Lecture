using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityConsole : MonoBehaviour
{
	public static GravityConsole instance;
	
	public GameObject planetPrefab;
	public Transform satelliteRef;
	public Transform planetRef;
	public float posRadius;
	
	public List<GravityPlanet> planetList;
	public GravityPlanet nowSelect;
	public PreferenceMenu planetPreference;
	
	public string nameParam
	{
		get { return nowSelect.name; }
		set 
		{ 
			nowSelect.name = value; 
		}
	}
	public InputField nameInput;
		
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
					nowSelect.mass = massInput;
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
	public InputField massInput;
		
	public float radius;
	public string radiusParam
	{
		get { return String.Empty; }
		set 
		{ 
			try
			{
				float radiusInput = float.Parse(value); 
				
				if(radiusInput > 0)
				{
					nowSelect.radius = radiusInput;
					radius = radiusInput; 
					// nowSelect.transform.localScale = Vector3.one * radius;
					radiusLog.text = String.Empty;
				}
				else
				{
					radiusLog.text = "*錯誤，半徑必須大於0";
				}
			
				
			}
			catch (Exception e)
			{
				radiusLog.text = "*錯誤，非數字輸入";
			} 
		}
	}
	public Text radiusLog;
	public InputField radiusInput;
	
	public float localPositionX;
	public string localPositionXParam
	{
		get { return String.Empty; }
		set 
		{ 
			try
			{
				localPositionX = float.Parse(value); 
				
				Vector3 fixedPosition = nowSelect.transform.position;
				fixedPosition.x = satelliteRef.position.x + localPositionX;
				nowSelect.transform.position = fixedPosition;
				
				UpdatePlanetDistance();
				localPositionXLog.text = String.Empty;
			}
			catch (Exception e)
			{
				localPositionXLog.text = "*錯誤，非數字輸入";
			}
		}
	}
	public Text localPositionXLog;
	public InputField localPositionXInput;
	
	public float localPositionY;
	public string localPositionYParam
	{
		get { return String.Empty; }
		set 
		{ 
			try
			{
				localPositionY = float.Parse(value); 
				
				Vector3 fixedPosition = nowSelect.transform.position;
				fixedPosition.y = satelliteRef.position.y + localPositionY;
				nowSelect.transform.position = fixedPosition;
				
				UpdatePlanetDistance();
				localPositionYLog.text = String.Empty;
			}
			catch (Exception e)
			{
				localPositionYLog.text = "*錯誤，非數字輸入";
			}
		}
	}
	public Text localPositionYLog;
	public InputField localPositionYInput;
	
	public float localPositionZ;
	public string localPositionZParam
	{
		get { return String.Empty; }
		set 
		{ 
			try
			{
				localPositionZ = float.Parse(value); 
				
				Vector3 fixedPosition = nowSelect.transform.position;
				fixedPosition.z = satelliteRef.position.z + localPositionZ;
				nowSelect.transform.position = fixedPosition;
				
				UpdatePlanetDistance();
				localPositionZLog.text = String.Empty;
			}
			catch (Exception e)
			{
				localPositionZLog.text = "*錯誤，非數字輸入";
			}
		}
	}
	public Text localPositionZLog;
	public InputField localPositionZInput;
	
	
	public Text planetDistanceInfo;
	
	
	public Transform astronutRef;
	
	
    void Awake()
    {
        GravityConsole.instance = this;
    }

	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void Select(GravityPlanet planetInfo)
	{
		nowSelect = planetInfo;
		
		nameInput.text = nowSelect.name;
		massInput.text = String.Format("{0}", nowSelect.mass);
		radiusInput.text = String.Format("{0:F3}", nowSelect.radius);
		
		Vector3 coord = nowSelect.transform.position - satelliteRef.position;
		
		localPositionXInput.text = String.Format("{0:F3}", coord.x);
		localPositionYInput.text = String.Format("{0:F3}", coord.y);
		localPositionZInput.text = String.Format("{0:F3}", coord.z);
		UpdatePlanetDistance();
		
		planetPreference.Show();
		
	}
	
	public void UpdatePlanetDistance()
	{
		planetDistanceInfo.text = String.Format("{0:F2} 萬公里", GetPlanetDistance() );
	}
	
	public float GetPlanetDistance()
	{
		return Vector3.Distance(nowSelect.transform.position, satelliteRef.position);
	}
	
	public void ClearAllPlanets()
	{
		/*foreach (Transform child in planetRef)
		{
			Destroy(child.gameObject);
		}*/
		for (int i=0; i< planetList.Count; i++)
		{
			Destroy(planetList[i].gameObject);
		}
		planetList.Clear();
	}
	
	public void CreatePlanet()
	{
		Vector3 randPosition = satelliteRef.position + UnityEngine.Random.onUnitSphere * satelliteRef.lossyScale.x * posRadius;
		
		GameObject planet = (GameObject)Instantiate(planetPrefab, randPosition, UnityEngine.Random.rotation, planetRef);
		
		planet.name = String.Format("行星{0}號", Mathf.RoundToInt(UnityEngine.Random.Range(0f, 9999f)) );
		
		GravityPlanet planetInfo = planet.GetComponent<GravityPlanet>();
		
		planetList.Add(planetInfo);
		
	}
	
	public void DeletePlanet()
	{
		planetList.Remove(nowSelect);
		Destroy(nowSelect.gameObject);
		
		planetPreference.Hide();
	}
	
}
