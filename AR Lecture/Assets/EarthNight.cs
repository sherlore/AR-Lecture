using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthNight : MonoBehaviour
{
	public Renderer myRen;
	// public Material myMat;
	
	public Transform sun;
	
    // Start is called before the first frame update
    void Start()
    {
        myRen = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        myRen.material.SetVector("_LightPos", sun.position);
		myRen.material.SetVector("_LightDir", sun.position - transform.position);
    }
}
