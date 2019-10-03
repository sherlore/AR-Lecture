using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDistance : MonoBehaviour
{
	public Transform shadowRef;
	public Transform moon;
	public Transform earth;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float disMoonToEarth = Vector3.Distance(moon.position, earth.position);
		Vector3 dirShadow = shadowRef.position - earth.position;
		
		transform.position = earth.position + dirShadow.normalized * disMoonToEarth;
		
        // transform.localPosition = Vector3.back * Vector3.Distance(moon.localPosition, earth.localPosition);
    }
}
