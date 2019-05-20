using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
	public bool isRotating;
	public Vector3 speed;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRotating)
		{
			transform.Rotate(speed * Time.deltaTime);
		}
    }
}
