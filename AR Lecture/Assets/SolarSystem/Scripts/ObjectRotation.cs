using UnityEngine;
using System.Collections;

public class ObjectRotation : MonoBehaviour {

	public float planetSpeedRotation = 1.0f;
	public bool useManager = true;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(useManager)
			transform.Rotate(-Vector3.up * Time.deltaTime * planetSpeedRotation * ConfigManager.instance.orbitSpeedInDaysPerSecond);
		else
			transform.Rotate(-Vector3.up * Time.deltaTime * planetSpeedRotation);
	}
}
