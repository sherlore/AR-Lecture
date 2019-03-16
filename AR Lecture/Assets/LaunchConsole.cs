using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchConsole : MonoBehaviour
{
	public Transform cam;
	public float launchSpeed;
	public float stateliteMass;
	public GameObject statelitePrefab;
	
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
		GameObject statelite = (GameObject)Instantiate(statelitePrefab, cam.position, cam.rotation);
		statelite.transform.localScale = Earth.instance.localScale * 0.5f;
		Rigidbody stateliteRb = statelite.GetComponent<Rigidbody>();
		stateliteRb.mass = stateliteMass;
		stateliteRb.velocity = cam.forward * launchSpeed;
	}
	
	public void SetLaunchSpeed(float val)
	{
		launchSpeed = val;
	}
	
	public void SetStateliteMass(float val)
	{
		stateliteMass = val;
	}
}
