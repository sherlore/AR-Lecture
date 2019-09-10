using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersionUI : MonoBehaviour
{
	public Text ui;
	
    // Start is called before the first frame update
    void Start()
    {
        ui.text = "Ver " + Application.version;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
