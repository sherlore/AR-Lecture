using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailTool : MonoBehaviour
{
	public TrailRenderer myTrail;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void OnDisable()
	{
		myTrail.Clear();
	}
}
