using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMutexLock : MonoBehaviour
{
	public bool lockOnMinimize;
	public PreferenceMenu planetPreference;
	public GameObject[] mutexObjects;
	
	
    // Start is called before the first frame update
    void Start()
    {
        lockOnMinimize = planetPreference.isMinimize;		
		foreach (GameObject child in mutexObjects)
		{
			child.SetActive(lockOnMinimize);
		}
    }

    // Update is called once per frame
    void Update()
    {
        if(lockOnMinimize && !planetPreference.isMinimize)
		{			
			foreach (GameObject child in mutexObjects)
			{
				child.SetActive(false);
			}
			lockOnMinimize = false;
		}
        else if(!lockOnMinimize && planetPreference.isMinimize)
		{			
			foreach (GameObject child in mutexObjects)
			{
				child.SetActive(true);
			}
			lockOnMinimize = true;
		}
    }
}
