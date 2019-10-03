using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolution : MonoBehaviour
{
	public float dayPerCycle;
	public float speed;
	public float beginOffset;
	
    // Start is called before the first frame update
    void Start()
    {
        speed = 360f/dayPerCycle/24f;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(Vector3.up * -1f * speed * Time.deltaTime * SimulatorConsole.instance.simulationSpeed);
        speed = 360f/dayPerCycle/24f;
		
		transform.localRotation = Quaternion.AngleAxis(speed * -1f * SimulatorConsole.instance.time + beginOffset, Vector3.up);
    }
}
