using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		info.SetMinimize(!info.isMinimize);
	}
}
