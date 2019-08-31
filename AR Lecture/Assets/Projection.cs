using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projection : MonoBehaviour
{
	public Transform mEarth;
	public Transform mSelf;
	
	public Transform pEarth;
	public float scale;
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = pEarth.position + mEarth.InverseTransformVector(mSelf.position - mEarth.position) * scale;
    }
}
