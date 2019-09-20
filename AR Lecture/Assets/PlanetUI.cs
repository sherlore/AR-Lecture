﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlanetUI : MonoBehaviour
{
	public int browseIndex;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject()) return;
		
		PlanetBrowser.instance.Browse(browseIndex);
	}
}
