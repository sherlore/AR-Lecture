﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolution : MonoBehaviour
{
	public float dayPerCycle;
	public float speed;
	
    // Start is called before the first frame update
    void Start()
    {
        speed = 360f/dayPerCycle/24f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * -1f * speed * Time.deltaTime * SimulatorConsole.instance.simulationSpeed);
    }
}
