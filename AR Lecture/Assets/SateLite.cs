using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SateLite : MonoBehaviour
{
	public TrailRenderer trail;
	public Rigidbody myRb;
	public Rigidbody earthRb;
	public float gCoef;
	public GameObject exp;
	
    // Start is called before the first frame update
    void Start()
    {
        earthRb = Earth.instance.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Earth.instance);
    }
	
	public void FixedUpdate()
	{
		Vector3 dir = Earth.instance.position - transform.position;
		float distance = dir.magnitude;
		
		myRb.AddForce(dir * gCoef * myRb.mass * earthRb.mass / (distance * distance) );
	}
	
	public void SetScale(float val)
	{
		transform.localScale = Vector3.one * val;
		trail.widthMultiplier = 0.01f * val;
	}
	
	void OnCollisionEnter(Collision collision)
    {
		if(collision.transform.CompareTag("Finish") )
		{		
			trail.transform.SetParent(transform.parent);
			Destroy(trail.gameObject, 5f);
			
			exp.transform.SetParent(transform.parent);
			exp.SetActive(true);
			Destroy(exp, 5f);
			
			Destroy(gameObject);
		}
    }
}
