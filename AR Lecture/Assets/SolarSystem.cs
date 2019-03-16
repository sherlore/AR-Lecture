using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
	public LineRenderer[] trails;
	public float originalScale = 0.03f;
	
	
    // Start is called before the first frame update
    void Start()
    {
        Rescale();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ConfigManager.instance.orbitSpeedInDaysPerSecond);
    }
		
	public void SetOrbitSpeedInDaysPerSecond(float val)
	{
		ConfigManager.instance.orbitSpeedInDaysPerSecond = val * transform.localScale.x;
	}
	
	public void SetHeight(float val)
	{
		transform.localPosition = Vector3.up * val;
		Recenter();
	}
	
	public void SetScale(float val)
	{
		transform.localScale = Vector3.one * originalScale * val;
		Rescale();
	}
	
	public void Rescale()
	{
		foreach(LineRenderer trail in trails)
		{
			trail.widthMultiplier = 0.26f * transform.localScale.x;
		}
		Recenter();
	}
	
	public void Recenter()
	{
		gameObject.BroadcastMessage("ReTrail");
	}
}
