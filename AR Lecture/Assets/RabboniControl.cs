using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RabboniControl : MonoBehaviour
{
	public string description;
	
    public abstract void Sync(Vector3 val);
}
