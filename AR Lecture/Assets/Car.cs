using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
	public GameObject checkPoint;
	public bool startMoving;
	
	public Rigidbody rb;
	public float acc;
	
	
	public int countFrame;
	public int count;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void FixedUpdate()
	{
		if(startMoving)
		{
			rb.AddForce(transform.forward * acc, ForceMode.Acceleration);
			if(count < countFrame)
			{
				count++;
			}
			else
			{
				count = 0;
				Instantiate(checkPoint, transform.position, transform.rotation);
			}
		}
		else
		{
			rb.velocity = Vector3.zero;
		}
	}
}
