using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

public class MoonEclipse : MonoBehaviour
{
	public Renderer myMat;
	public Color normal;
	public Color fullEcipse;
	public float angleEclipseStart;
	public float angleEclipseFull;
	private float angleEclipseLerpRange;
	public Transform moon;
	public Transform earth;
	public Transform shadow;
	
	// public Text angleText;
	
    // Start is called before the first frame update
    void Start()
    {
        myMat.material.SetInt("_StencilTest", 3);
		angleEclipseLerpRange = angleEclipseStart - angleEclipseFull;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirMoonToEarth = moon.position - earth.position;
		Vector3 dirShadowToEarth = shadow.position - earth.position;
		
		float eclispeAngle = Vector3.Angle(dirMoonToEarth, dirShadowToEarth);
		// angleText.text = "" + eclispeAngle;
		
		myMat.material.SetColor("_Color", Color.Lerp(normal, fullEcipse, (angleEclipseStart - eclispeAngle)/angleEclipseLerpRange   ) );
    }
}
