using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitGround : MonoBehaviour
{
	public Transform ground;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 myPos = transform.position;
		myPos.y = ground.position.y;
		
        transform.position = myPos;
    }
}
