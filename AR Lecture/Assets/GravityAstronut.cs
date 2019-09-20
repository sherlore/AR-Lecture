using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityAstronut : MonoBehaviour
{
	const float coefG = 0.667f;
	public Rigidbody rb;
	public bool arrivePlanet = false;
	public GameObject trail;
	
	public float launchTime;
	public Transform landingPlanet;
	public Vector3 landingTransformScale;
	public Vector3 landingPlanetInitScale;
	
	public PreferenceMenu landingUI;
	public Text landingTimeInfo;
	public Text landingPlanetInfo;
	
    // Start is called before the first frame update
    void Start()
    {
        launchTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
		if(arrivePlanet)
		{
			transform.localScale = landingTransformScale * landingPlanetInitScale.x / landingPlanet.localScale.x;
		}
    }
	
	void FixedUpdate()
	{
		if(arrivePlanet) return;
		
		Vector3 totalGravity = Vector3.zero;
		
		for(int i=0; i< GravityConsole.instance.planetList.Count; i++)
		{
			GravityPlanet planet = GravityConsole.instance.planetList[i];
			Vector3 dir = planet.transform.position - transform.position;
			
			totalGravity += dir.normalized * planet.mass / dir.sqrMagnitude;
		}
		
		rb.AddForce(totalGravity * coefG, ForceMode.Acceleration);
	}
	
	void OnCollisionEnter(Collision collision)
    {		
		arrivePlanet = true;
		landingPlanet = collision.transform;
		transform.parent = landingPlanet;
		landingTransformScale = transform.localScale;
		landingPlanetInitScale = landingPlanet.localScale;
		
		Vector3 upward = transform.position - collision.transform.position;
		
		float dot = Vector3.Dot(transform.up, upward.normalized);
		Vector3 forward = Vector3.one;
		
		if(dot == -1f)
		{
			Debug.Log("A Dot: " + dot);
			forward = transform.forward;
			transform.rotation = Quaternion.LookRotation(forward, upward);
		}
		else if(dot == 1f)
		{
			Debug.Log("B Dot: " + dot);
		}
		else
		{
			Debug.Log("Dot: " + dot);
			forward = Vector3.ProjectOnPlane(transform.up, upward);
			transform.rotation = Quaternion.LookRotation(forward, upward);
		}		
		
        Destroy(rb);
        Destroy(trail);
		
		Invoke("ShowLandingUI", 0.5f);
		Invoke("HideLandingUI", 20f);
    }
	
	void ShowLandingUI()
	{
		landingTimeInfo.text = System.String.Format("{0:F2}秒", Time.time - launchTime);
		landingPlanetInfo.text = landingPlanet.name;
		
		landingUI.Show();
	}
	
	void HideLandingUI()
	{		
		landingUI.Hide();
	}
}
