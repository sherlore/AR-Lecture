using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetBrowser : MonoBehaviour
{
	public static PlanetBrowser instance;
	public GameObject[] infos;
	public int myIndex; 
	public ScrollRect myScrollRect;
	public bool isMinimize;
	
	public RectTransform myRect;
	public Vector2 initSize;
	public Vector3 hidePos;
	public Vector3 showPos;
	
	// public float browseTime;
	
	
	void Awake()
	{
		instance = this;
	}
	
    // Start is called before the first frame update
    void Start()
    {
		Minimize();
        for(int i=0; i<infos.Length; i++)
		{
			infos[i].SetActive(false);
		}
    }
	
	public void Minimize()
	{
		isMinimize = true;
		myScrollRect.enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
		if(!isMinimize)
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, 0.1f);
			// myRect.sizeDelta = Vector2.Lerp(myRect.sizeDelta, Vector2.one, 0.1f);
			// showPos = transform.localPosition;
		else
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 0.1f);
			// myRect.sizeDelta = Vector2.Lerp(myRect.sizeDelta, Vector2.zero, 0.1f);
			// hidePos = transform.localPosition;
    }
	
	public void Browse(int index)
	{
		myScrollRect.verticalNormalizedPosition = 1f;
		transform.localScale = Vector3.zero;
		isMinimize = false;
		infos[myIndex].SetActive(false);
		myIndex = index;
		infos[myIndex].SetActive(true);
		myScrollRect.enabled = true;
	}
}
