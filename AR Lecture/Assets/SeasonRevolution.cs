using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonRevolution : MonoBehaviour
{
	public float sunFar;
	public float aAxis;
	public float bAxis;
	
	public Transform planet;
	public float dayPerCycle;
	public float rSpeed;  //radian / hour 
	public float scale;
	public float beginOffset;
	private float beginOffsetRadian;
	
	
	public string tag;
	
    // Start is called before the first frame update
    void Start()
    {
        rSpeed = Mathf.PI * 2f / dayPerCycle / 24f;
		beginOffsetRadian = beginOffset * Mathf.PI / 180f;
    }

    // Update is called once per frame
    void Update()
    {
		beginOffsetRadian = beginOffset * Mathf.PI / 180f;
		
        Vector3 x = Vector3.right * (sunFar - aAxis + aAxis * Mathf.Cos(rSpeed * SimulatorConsole.instance.time + beginOffsetRadian) );
		Vector3 z = Vector3.forward * (bAxis * Mathf.Sin(rSpeed * SimulatorConsole.instance.time + beginOffsetRadian) );
		
        planet.localPosition = (x + z) * scale;
		
		if(!Input.GetButtonDown("Jump") ) return;
		
		float angle = rSpeed * SimulatorConsole.instance.time + beginOffsetRadian;
		angle *= 180f/Mathf.PI;
		Debug.Log(tag + Mathf.RoundToInt(angle)%360);
    }
}
