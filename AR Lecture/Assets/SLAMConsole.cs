using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLAMConsole : MonoBehaviour
{
	public static SLAMConsole instance;	
	public Vector3 planePosition;
	public Quaternion planeRotation;
	
	public Transform ARroot;
	
	public Camera cam;
	// public bool isARmode;
	
    void Awake()
    {
        SLAMConsole.instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SetARMode(bool val)
	{
		if(val)
		{
			cam.clearFlags = CameraClearFlags.SolidColor;
		}
		else
		{
			cam.clearFlags = CameraClearFlags.Skybox;
		}
		
	}
	
	public void PinARObject()
	{
		ARroot.position = planePosition;
		ARroot.rotation = planeRotation;
	}
}
