using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionRot : MonoBehaviour
{
	public Transform root;
	public Transform cam;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = cam.rotation * Quaternion.Inverse(root.rotation);
    }
}
