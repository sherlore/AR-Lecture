﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateConsole : MonoBehaviour
{
	public Transform earthOrbitCenter;
	public Transform sun;
	public Text dateText;
	
	
	public Transform observer;
	public Transform earth;
	public Text timeText;
	
	// public DateTime dateNow;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ComputeDate();
    }
	
	public void ComputeDate()
	{
		float angle = Vector3.SignedAngle(earthOrbitCenter.forward, sun.forward, sun.up);
		if(angle < 0) angle += 360f;
		
		DateTime dateSummer = new DateTime(2019, 6, 22, 12, 0, 0, DateTimeKind.Utc);
		
		float daysFormSummer = Mathf.Lerp(0, 365.256f, angle/360f);
		
		DateTime dateNowUtc = dateSummer.AddDays(daysFormSummer);
		DateTime dateNow = dateNowUtc.AddHours(CoordConsole.instance.timeZone);
		
		Debug.Log("dateNow: " + dateNow);
		dateText.text = String.Format("日期: {0}", dateNow.ToString("yyyy/MM/dd") );
		timeText.text = String.Format("時間: {0}", dateNow.ToString("HH:mm") );
	}
}
