using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// [ExecuteInEditMode]
public class EditorScript : MonoBehaviour
{
	// public RectOffset myPadding;
	public int index;
    // Start is called before the first frame update
    void Start()
    {
        // AdCheck[] groups = GetComponentsInChildren<AdCheck>();
		
		// foreach(AdCheck temp in groups)
		// {
			// Destroy(temp);
		// }
		
		// Stage stage = GetComponentInChildren<Stage>();
		// stage.noise = GetComponentInChildren<NoiseControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2" ) )
		{
			Debug.Log("Screenshot");
			ScreenCapture.CaptureScreenshot(string.Format("Screenshot_{0}_{1}_{2}.png" , Screen.width, Screen.height, index) );
			index++;
		}
    }
}
