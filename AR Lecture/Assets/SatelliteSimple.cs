using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteSimple : MonoBehaviour
{
	public Rigidbody rb;
	public float initVelocity;	
	public float acc;
	public GameObject centripetalVFX;
	public TrailRenderer trail;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CentripetalCenter.instance.makeCentripetalForce && !centripetalVFX.activeInHierarchy)
		{
			centripetalVFX.SetActive(true);
		}
        else if(!CentripetalCenter.instance.makeCentripetalForce && centripetalVFX.activeInHierarchy)
		{
			centripetalVFX.SetActive(false);
		}
		
		if(centripetalVFX.activeInHierarchy)
		{
			centripetalVFX.transform.LookAt(CentripetalCenter.instance.transform);
		}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if(!CentripetalCenter.instance.makeCentripetalForce) return;
		
		Vector3 centripetalDir = CentripetalCenter.instance.transform.position - transform.position;
        rb.AddForce(acc * centripetalDir.normalized, ForceMode.Acceleration);
    }
	
	public void Launch()
	{		
		// acc = initVelocity * initVelocity / Vector3.Distance(transform.position, CentripetalCenter.instance.transform.position);
		
		rb.velocity = transform.forward * initVelocity;
		trail.widthMultiplier = transform.lossyScale.x/2f;
	}
}
