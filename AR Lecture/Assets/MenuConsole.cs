using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuConsole : MonoBehaviour
{
	public PreferenceMenu[] menus;
	public int nowSelect = 0;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SwitchMenu(int val)
	{
		if(val == nowSelect)
		{
			menus[nowSelect].SetMinimize();
		}
		else
		{
			menus[nowSelect].Hide();
			nowSelect = val;
			menus[nowSelect].Show();
		}
	}
}
