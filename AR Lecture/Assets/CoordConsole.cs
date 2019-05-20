using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoordConsole : MonoBehaviour
{
	public Transform observer;
	public Transform coordRef;
	
	public float latitude;
	public float longtitude;
	
	public Text latitudeText;
	public Text longtitudeText;
	
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
		longtitude = val * -1f;
		longtitudeText.text = string.Format("經度: {0}", val);
		SetCoord();
	}
	
	public void SetCoord()
	{
		observer.localRotation = Quaternion.identity;
		observer.RotateAround(coordRef.position, coordRef.right, latitude);
		observer.RotateAround(coordRef.position, coordRef.forward, longtitude);
	}
}
