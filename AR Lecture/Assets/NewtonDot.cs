using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewtonDot : MonoBehaviour
{
	public Text timerInfo;
	public Text distanceInfo;
	public Text velocityInfo;
	public UIZoom info;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnEnable()
	{
		info.SetMinimize(false);
	}
	
	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject()) return;
		
		info.SetMinimize(!info.isMinimize);
	}
	
	public void ShowAllInfo()
	{
		info.SetMinimize(false);
	}
	
	public void HideAllInfo()
	{
		info.SetMinimize(true);
	}
}
