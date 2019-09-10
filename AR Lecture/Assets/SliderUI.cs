using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
	public string strFormat;
	public Text info;
		
	public void UpdateValue(float val)
	{
		info.text = System.String.Format(strFormat, val);
	}
}
