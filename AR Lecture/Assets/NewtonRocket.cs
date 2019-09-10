using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewtonRocket : MonoBehaviour
{
	public bool isLaunching;
	// public Rigidbody rb;
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
	
	public GameObject burstEngine;
	public Text stopReason;
	public UIZoom info;
	
	public float velocity;
	public float mass;
	public float acc;
	
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
			
			if(Time.fixedTime - launchTime >= limitedTime)
			{
				stopReason.text = "因抵達\n極限飛行時間\n而停止";
				info.SetMinimize(false);
				Stop();
				return;
			}			
			else if(Vector3.Distance(launchPos, transform.position) >= limitedDistance)
			{
				stopReason.text = "因抵達\n極限飛行距離\n而停止";
				info.SetMinimize(false);
				Stop();
				return;
			}
			
			float t = Time.fixedTime - launchTime;
			float displacement = initVelocity * t + 0.5f * acc * t * t ;
			transform.localPosition = Vector3.forward * displacement;
			
			if( Time.fixedTime - dotTimer >= dotPeriod )
			{
				dotTimer = Time.fixedTime;
				GameObject dot = (GameObject)Instantiate(dotPrefab, dotRef.position, dotRef.rotation, transform.parent);
				dot.transform.localScale = Vector3.one;
				
				// float nowVelocity = rb.velocity.magnitude;
				float nowVelocity = velocity;
				float accVelocity = nowVelocity - initVelocity;
				float halfFrame = 0.5f * Time.fixedDeltaTime;
				float error = halfFrame * accVelocity;
				
				
				NewtonDot dotInfo = dot.GetComponent<NewtonDot>();
				dotInfo.timerInfo.text = System.String.Format("打點  {0:F2}s", Time.fixedTime - launchTime);
				// dotInfo.distanceInfo.text = System.String.Format("位移: {0:F3}", Vector3.Distance(launchPos, transform.position) - error);
				dotInfo.distanceInfo.text = System.String.Format("位移: {0:F3}", displacement);
				dotInfo.velocityInfo.text = System.String.Format("速度: {0:F3}", nowVelocity);
				
				dot.SetActive(true);
			}
			
			// rb.AddForce(transform.forward * burstForce);
			// rb.velocity += transform.forward * (burstForce/rb.mass) * Time.fixedDeltaTime;
			velocity += acc * Time.fixedDeltaTime;
			
			
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
		dotTimer = Time.fixedTime;
		trail.widthMultiplier *= transform.lossyScale.x;
		
		
		// rb.velocity = transform.forward * initVelocity;
		acc = burstForce/mass;		
		velocity = initVelocity;
		
	}
	
	public void Stop()
	{
		isLaunching = false;
		burstEngine.SetActive(false);
		
		// rb.velocity = Vector3.zero;
		velocity = 0;
		
		Debug.Log("Stop");
	}
}
