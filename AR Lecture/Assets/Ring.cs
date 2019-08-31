using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
	public LineRenderer ring;
	public float radius;
	public int ringResolution;
	
    // Start is called before the first frame update
    void Start()
    {
        DrawRing();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void DrawRing()
	{
		ring.positionCount = ringResolution + 1;
				
		float angleUnit = 360f/ringResolution;
		// Debug.Log("angleUnit: " + angleUnit);

		for(int i = 0; i < ringResolution + 1; i++)
		{
			Vector3 x = Vector3.right * Mathf.Cos(Mathf.Deg2Rad * angleUnit * i) * radius;
			Vector3 z = Vector3.forward * Mathf.Sin(Mathf.Deg2Rad * angleUnit * i) * radius;
			ring.SetPosition(i, x+z );
		}		
	}
}
