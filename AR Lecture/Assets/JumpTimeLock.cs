using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTimeLock : MonoBehaviour
{
	public GameObject btn;
	
    void OnEnable()
    {
        btn.SetActive(false);
    }

    void OnDisable()
    {
        btn.SetActive(true);
    }
}
