using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPreference : MonoBehaviour
{
	public Vector3 initScale;
	public float initHeight;
	
    // Start is called before the first frame update
    void Start()
    {
        // initScale = transform.localScale;
		transform.localScale = initScale;
		// FixHeight(initHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void FixScale(float val)
	{
		// Debug.Log("FixScale: " + val);
		
		transform.localScale = initScale * val;
		
		// BroadcastMessage("RefreshOrbitWidth", SendMessageOptions.DontRequireReceiver);
		
	}
	
	public void FixHeight(float val)
	{
		// Debug.Log("FixScale: " + val);
		
		transform.localPosition = Vector3.up * initHeight * val;
	}
	
	public void FixRotation(float val)
	{
		// Debug.Log("FixScale: " + val);
		
		transform.localEulerAngles = Vector3.up * val;
	}
}
