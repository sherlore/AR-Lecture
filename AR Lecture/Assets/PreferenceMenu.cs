using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreferenceMenu : MonoBehaviour
{
	public bool isMinimize;
	public Vector3 minimized;
	public float minimizedTime;
	public float minimizedSpeed = 2f;
	
	public Image menuBtn;
	public Color showColor;
	public Color hideColor;
	
	
    // Start is called before the first frame update
    void Start()
    {
        minimizedTime = Time.time;
		
		if(isMinimize)
		{
			menuBtn.color = hideColor;
		}
		else
		{
			menuBtn.color = showColor;
		}
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
	
	public void SetMinimize()
	{
		isMinimize = !isMinimize;
        minimizedTime = Time.time;
		
		if(isMinimize)
		{
			menuBtn.color = hideColor;
		}
		else
		{
			menuBtn.color = showColor;
		}
	}
	
	public void Show()
	{
		if(isMinimize)
		{
			isMinimize = false;
			minimizedTime = Time.time;
			menuBtn.color = showColor;
		}
	}
	
	public void Hide()
	{
		if(!isMinimize)
		{
			isMinimize = true;
			minimizedTime = Time.time;
			menuBtn.color = hideColor;
		}
	}
}
