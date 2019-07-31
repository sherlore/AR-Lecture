using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferenceMenu : MonoBehaviour
{
	public bool isMinimize;
	public Vector3 minimized;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(!isMinimize)
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, 0.1f);
			// myRect.sizeDelta = Vector2.Lerp(myRect.sizeDelta, Vector2.one, 0.1f);
			// showPos = transform.localPosition;
		else
			transform.localScale = Vector3.Lerp(transform.localScale, minimized, 0.1f);
			// myRect.sizeDelta = Vector2.Lerp(myRect.sizeDelta, Vector2.zero, 0.1f);
			// hidePos = transform.localPosition;        
    }
	
	public void SetMinimize()
	{
		isMinimize = !isMinimize;
	}
}
