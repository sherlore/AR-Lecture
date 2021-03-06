﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIZoom : MonoBehaviour
{
	public Vector3 initScale;
	public bool isMinimize;
	public Vector3 minimized;
	public float minimizedTime;
	public float minimizedSpeed = 2f;
	
    // Start is called before the first frame update
    void Start()
    {
		transform.localScale = initScale;
        minimizedTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
		if(!isMinimize)
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, (Time.time - minimizedTime) * minimizedSpeed );
			// myRect.sizeDelta = Vector2.Lerp(myRect.sizeDelta, Vector2.one, 0.1f);
			// showPos = transform.localPosition;
		else
			transform.localScale = Vector3.Lerp(transform.localScale, minimized, (Time.time - minimizedTime) * minimizedSpeed );
			// myRect.sizeDelta = Vector2.Lerp(myRect.sizeDelta, Vector2.zero, 0.1f);
			// hidePos = transform.localPosition;        
    }
	
	public void SetMinimize(bool val)
	{
		isMinimize = val;
        minimizedTime = Time.time;
	}
}
