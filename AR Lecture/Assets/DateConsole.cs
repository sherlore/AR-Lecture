using System;
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
	
	public DateTime dateNow;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ComputeDate();
		ComputeTime();
    }
	
	public void ComputeDate()
	{
		float angle = Vector3.SignedAngle(earthOrbitCenter.forward, sun.forward, sun.up);
		if(angle < 0) angle += 360f;
		
		DateTime dateSummer = new DateTime(2019, 6, 22);
		
		float daysFormSummer = Mathf.Lerp(0, 366f, angle/360f);
		
		dateNow = dateSummer.AddDays(daysFormSummer);
		
		Debug.Log("dateNow: " + dateNow);
		dateText.text = String.Format("日期: {0}", dateNow.ToString("yyyy/MM/dd") );
	}
	
	public void ComputeTime()
	{
		// Debug.Log("sun.up:" + sun.up);
		// Debug.Log("observer.up:" + observer.up);
		Vector3 observerHeading = Vector3.ProjectOnPlane(observer.up, sun.up).normalized;
		
		
		// Debug.Log("observerHeading:" + observerHeading);
		// Debug.Log("earth.position - sun.position:" + (earth.position - sun.position) );
		Vector3 midnightDirection = Vector3.ProjectOnPlane(earth.position - sun.position, sun.up);
		// Debug.Log("midnightDirection:" + midnightDirection);
		
		float angle = Vector3.SignedAngle(observerHeading, midnightDirection, sun.up);
		if(angle < 0) angle += 360f;
		// Debug.Log(angle);
		
		DateTime timeMidnight = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 0, 0, 0);
		float hoursFormNoon = Mathf.Lerp(0, 24f, angle/360f);
		// Debug.Log(hoursFormNoon);
		
		DateTime timeNow = timeMidnight.AddHours(hoursFormNoon);
		
		// Debug.Log("timeNow: " + timeNow);
		timeText.text = String.Format("時間: {0}", timeNow.ToString("HH:mm") );
		
	}
}
