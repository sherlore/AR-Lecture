using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoordConsole : MonoBehaviour
{
	public static CoordConsole instance;	
	public Transform observer;
	public Transform coordRef;
	
	public float latitude;
	public float longtitude;
	
	public Text latitudeText;
	public Text longtitudeText;
	
	public float timeZone;
	
    // Start is called before the first frame update
    void Awake()
    {
        CoordConsole.instance = this;
		SerLatitude(latitude);
		SerLongtitude(longtitude);
    }
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SerLatitude(float val)
	{
		latitude = val;
		latitudeText.text = string.Format("緯度: {0}", val);
		SetCoord();
	}
	
	public void SerLongtitude(float val)
	{
		longtitude = val;
		longtitudeText.text = string.Format("經度: {0}", longtitude);
		
		timeZone = Mathf.FloorToInt(longtitude/15f);
		
		SetCoord();
	}
	
	public void SetCoord()
	{
		observer.localRotation = Quaternion.identity;
		observer.RotateAround(coordRef.position, coordRef.right, latitude);
		observer.RotateAround(coordRef.position, coordRef.forward, longtitude * -1f);
	}
}
