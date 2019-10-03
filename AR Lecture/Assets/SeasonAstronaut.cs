using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonAstronaut : MonoBehaviour
{
	public Transform pinRef;
	public Transform ViewRef;
	public Transform astronautHead;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = Vector3.ProjectOnPlane(ViewRef.forward, pinRef.up);
		transform.rotation = Quaternion.LookRotation(forward, pinRef.up);
		
		astronautHead.rotation = Quaternion.LookRotation(ViewRef.forward, pinRef.up);
    }
}
