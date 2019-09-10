using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewStartPoint : MonoBehaviour
{
	public Text burstForceInfo;
	public Text massInfo;
	public Text InitvelocityInfo;
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
	
	public void DeleteRocket()
	{
		Destroy(gameObject);
	}
}
