using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrailConsole : MonoBehaviour
{
	public Transform sun;
	// public Transform moon;
	
	public GameObject trailPrefab;
	public GameObject nowTrail;
	public TrailRenderer nowTrailRenderer;
	bool drawTrail;
	public List<GameObject> trailSet;
	// public Transform skySphere;
	
	public Image colorButtonImg;
	public Color drawColor;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
    public bool DrawTrail
    {
        get { return drawTrail; }
        set
        {
            drawTrail = value;
			if(drawTrail)
			{
				AddTrail();
			}
			else
			{
				IndependTrail();
			}
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
	
	public void RandomColor()
	{
		// drawColor = Random.ColorHSV(0, 1, 0, 1, 1, 1);
		drawColor = new Color(Random.Range(0, 1f) , Random.Range(0, 1f), Random.Range(0, 1f) );
		colorButtonImg.color = drawColor;
		SetTrailColor(drawColor);
	}
	
	public void CheckDrawTrail()
	{
		if(drawTrail && nowTrail == null)
		{
			AddTrail();
		}
	}
	
	public void SetTrailColor(Color val)
	{
		nowTrailRenderer.startColor = drawColor;
		nowTrailRenderer.endColor = drawColor;
	}
	
	public void ClearTrail()
	{
		for(int i=0; i<trailSet.Count; i++)
		{
			Destroy(trailSet[i]);
		}
		trailSet.Clear();
	}
	
	public void IndependTrail()
	{
		if(nowTrail != null)
		{
			nowTrail.transform.parent = null;
			nowTrail = null;
		}
	}
	
	public void AddTrail()
	{
		GameObject newTrail = (GameObject)Instantiate(trailPrefab, sun);
		trailSet.Add(newTrail);
		nowTrail = newTrail;
		nowTrailRenderer = nowTrail.GetComponent<TrailRenderer>();
		SetTrailColor(drawColor);
	}
}
