using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonWatcher : MonoBehaviour
{
	public Transform moon;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(moon);
    }
}
