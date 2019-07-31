using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


[System.Serializable]
public class RollEvent : UnityEvent<float>
{
}

public class RollSlider : MonoBehaviour
{
	public Text title;
	public string titleString;
	public float paramVal;
	
	public float rollVal;
	public float scaleSpeed = 1f;
	public RollEvent rollEvent;
	
    // Start is called before the first frame update
    void Start()
    {
		// paramVal = 1f;
		title.text = System.String.Format(titleString, paramVal);
    }

    // Update is called once per frame
    void Update()
    {
        if(rollVal != 0)
		{
			paramVal += rollVal * paramVal * Time.deltaTime;
			paramVal = paramVal < 0 ? 0: paramVal;
			
			title.text = System.String.Format(titleString, paramVal);
			
			rollEvent.Invoke(paramVal);
		}
    }
	
	public void SetRoll(float val)
	{
		rollVal = Mathf.Lerp(-1f, 1f, (val+1f)/2f  ) * scaleSpeed;		
	}
}
