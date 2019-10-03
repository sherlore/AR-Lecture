using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GravityPlanet : MonoBehaviour, IPointerDownHandler
{
	public float mass = 5.97f;
	public float radius;
	
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * radius, 0.05f);
    }
	
	/*void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject()) return;
		
		GravityConsole.instance.Select(this);
	}*/
	
	public void OnPointerDown (PointerEventData data)
	{
		GravityConsole.instance.Select(this);
	}
	
}
