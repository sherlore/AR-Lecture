using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
	public static Transform instance;
	
	public float originalScale = 0.7f;
	public float nowScale = 0.7f;
	
	public Transform tfLight;
	public Renderer nightEarth;
	// public GameObject nightEarthGO;
	
	public Rigidbody rb;
	
    // Start is called before the first frame update
    void Start()
    {
		Earth.instance = transform;
		
        // nightEarth = nightEarthGO.GetComponent<Renderer>();
		RefreshDayNight();
		
		// gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
	
	public void SetMass(float val)
	{
		rb.mass = val;
	}
	
	public void RefreshDayNight()
	{
		nightEarth.material.SetVector("_LightPos", tfLight.position);
		nightEarth.material.SetVector("_LightDir", tfLight.forward);
	}
	
	public void SetHeight(float val)
	{
		transform.localPosition = Vector3.up * val;
		RefreshDayNight();
	}
	
	public void SetScale(float val)
	{
		nowScale = originalScale * val;
		transform.localScale = Vector3.one * nowScale;
		RefreshDayNight();
	}
}
