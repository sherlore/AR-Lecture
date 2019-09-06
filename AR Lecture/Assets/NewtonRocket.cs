using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonRocket : MonoBehaviour
{
	public bool isLaunching;
	public Rigidbody rb;
	// public Vector3 velocity;
	public float initVelocity;
	public float burstForce;
	
	public float launchTime;
	public float limitedTime;
	
	public Vector3 launchPos;
	public float limitedDistance;
	
	public float dotTimer;	
	public float dotPeriod;
	
	public GameObject dotPrefab;
	public Transform dotRef;
	
	public bool isFixedLaunch;
	
	public TrailRenderer trail;
	
	// public float velocity;
	// public float mass;
	// public float acc;
	
    // Start is called before the first frame update
    void Start()
    {
        dotPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // velocity = rb.velocity;
    }
		
    void FixedUpdate()
    {
		
		if(isFixedLaunch)
		{
			Launch();
			isFixedLaunch = false;
			// return;
		}
				
		if(isLaunching)
		{
			
			if(Time.fixedTime - launchTime >= limitedTime || Vector3.Distance(launchPos, transform.position) >= limitedDistance)
			{
				Stop();
				return;
			}
			
			// rb.velocity += transform.forward * (burstForce/rb.mass) * Time.fixedDeltaTime;
			
			if( Time.fixedTime - dotTimer >= dotPeriod )
			{
				dotTimer = Time.fixedTime;
				GameObject dot = (GameObject)Instantiate(dotPrefab, dotRef.position, dotRef.rotation);
				dot.transform.localScale = transform.lossyScale;
				
				//Physics run cord at halfFrame
				float nowVelocity = rb.velocity.magnitude;
				float accVelocity = nowVelocity - initVelocity;
				float halfFrame = 0.5f * Time.fixedDeltaTime;
				float error = halfFrame * accVelocity;
				// Debug.Log(System.String.Format("halfFrameDisplacement  {0:F5}s", halfFrameDisplacement) );
				
				
				NewtonDot dotInfo = dot.GetComponent<NewtonDot>();
				dotInfo.timerInfo.text = System.String.Format("打點  {0:F5}s", Time.fixedTime - launchTime);
				// dotInfo.distanceInfo.text = System.String.Format("位移: {0:F5}", Vector3.Distance(launchPos, transform.position) - halfFrameDisplacement);
				dotInfo.distanceInfo.text = System.String.Format("位移: {0:F5}", Vector3.Distance(launchPos, transform.position) - error);
				dotInfo.velocityInfo.text = System.String.Format("速度: {0:F5}", nowVelocity);
				
				dot.SetActive(true);
			}
			
			rb.AddForce(transform.forward * burstForce);
			// rb.velocity += transform.forward * (burstForce/rb.mass) * Time.fixedDeltaTime;
			
			
			
		}
		
    }
	
	
	public void FixedTimeLaunch()
	{
		isFixedLaunch = true;
	}
	
	public void Launch()
	{
		isLaunching = true;
		launchTime = Time.fixedTime;
		launchPos = transform.position;
		// dotTimer = Time.fixedTime + Time.fixedDeltaTime;
		dotTimer = Time.fixedTime;
		trail.widthMultiplier *= transform.lossyScale.x;
		// velocity = initVelocity;
		// acc = burstForce/mass;		
		rb.velocity = transform.forward * initVelocity;
	}
	
	public void Stop()
	{
		isLaunching = false;
		rb.velocity = Vector3.zero;
		// velocity = 0;
		Debug.Log("Stop");
	}
}
