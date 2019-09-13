using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentripetalCenter : MonoBehaviour
{
	public static CentripetalCenter instance;
	public GameObject centripetalVFX;
	public bool makeCentripetalForce;
	public bool makeCentripetalForceParam
	{
		get { return makeCentripetalForce; }
		set 
		{ 
			makeCentripetalForce = value;
			centripetalVFX.SetActive(makeCentripetalForce);
		}
	}
	
    void Awake()
    {
        CentripetalCenter.instance = this;
    }
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
