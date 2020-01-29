using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabboniConsole : MonoBehaviour
{
	public static RabboniConsole instance;
	
	public Transform rabboniConnectionParent;
	public GameObject rabboniConnectionPrefab;
	
    public string[] deviceName = new string[]{"NAXSEN", "Rabboni", "rabboni", "RABBONI"};
		
	public Text statusText;	
		
	public List<RabboniConnection> rabboniConnections = new List<RabboniConnection>();
	public List<string> rabboniList = new List<string>();
		
	public Button btnScan;
	public Button btnStopScan;
	
	public List<RabboniControl> rabboniControls = new List<RabboniControl>();
	
	public string ByteArrayToString(byte[] ba)
	{
	  return System.BitConverter.ToString(ba).Replace("-","");
	}
	
	string FullUUID (string uuid)
	{
		return "0000" + uuid + "-0000-1000-8000-00805F9B34FB";
	}
	
	bool IsEqual(string uuid1, string uuid2)
	{
		if (uuid1.Length == 4)
			uuid1 = FullUUID (uuid1);
		if (uuid2.Length == 4)
			uuid2 = FullUUID (uuid2);

		return (uuid1.ToUpper().Equals(uuid2.ToUpper()));
	}
	
	void Awake()
	{
		instance = this;
	}
	
    // Start is called before the first frame update
    void Start()
    {		
		Initialize();
    }
	
	public void CreateNewConnection()
	{
		GameObject newConnection = (GameObject)Instantiate(rabboniConnectionPrefab, rabboniConnectionParent);
		newConnection.SetActive(true);
		newConnection.transform.SetSiblingIndex(rabboniConnectionParent.childCount-2);
	}
	
	public void AddConnection(RabboniConnection val)
	{
		rabboniConnections.Add(val);
	}
	
	public void RemoveConnection(RabboniConnection val)
	{
		rabboniConnections.Remove(val);
	}
	
	public void Initialize()
	{
		btnScan.gameObject.SetActive(false);
		btnStopScan.gameObject.SetActive(false);
				
		statusText.text = "正在啟動藍芽功能";

		BluetoothLEHardwareInterface.Initialize (true, false, () => {
			
			// SetState (States.Scan, 0.1f);
			statusText.text = "藍芽功能啟動成功";
			btnScan.gameObject.SetActive(true);

		}, (error) => {
			
			statusText.text = "藍芽功能啟動失敗，請確認開啟藍芽設定";
			BluetoothLEHardwareInterface.Log ("Error: " + error);
		});
	}
	
	public void BLEDisconnect(string address)
	{
		for(int i=0; i<rabboniConnections.Count; i++)
		{
			if(rabboniConnections[i].targetAddress == address)
			{
				rabboniConnections[i].OnBLEDisconnect();
			}
		}
	}
	
	public void Scan()
	{
		rabboniList.Clear();
		
		for(int i=0; i<rabboniConnections.Count; i++)
		{
			rabboniConnections[i].SetScanList(rabboniList);
		}
				
		statusText.text = "正在掃描Rabboni...";
		
		btnScan.gameObject.SetActive(false);
		btnStopScan.gameObject.SetActive(true);

		BluetoothLEHardwareInterface.ScanForPeripheralsWithServices (null, (address, name) => {

			// we only want to look at devices that have the name we are looking for
			// this is the best way to filter out devices
			for(int index = 0; index < deviceName.Length; index++)
			{
				if (name.Contains (deviceName[index]))
				{
					// _workingFoundDevice = true;
					
					rabboniList.Add(address);
					
					
					for(int i=0; i<rabboniConnections.Count; i++)
					{
						rabboniConnections[i].SetScanList(rabboniList);
					}
				}
			}
		}, null, false, false);
	}
	
	void OnDestroy()
	{
		StopScan();
	}
	
	public void StopScan()
	{
		BluetoothLEHardwareInterface.StopScan ();
		statusText.text = "已停止掃描";
		btnScan.gameObject.SetActive(true);
		btnStopScan.gameObject.SetActive(false);
	}
	
}
