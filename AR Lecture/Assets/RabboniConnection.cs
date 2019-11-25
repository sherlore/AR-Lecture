using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabboniConnection : MonoBehaviour
{
	public string ServiceUUID = "1600";
	public string Characteristic = "1601";
	
	public Dropdown sensorList;
	public GameObject scanHint;
	
	public bool isConnecting;
	public Button connectBtn;
	public Button disconnectBtn;
	
	public List<string> myRabonniList = new List<string>();
	public int selectIndex;
	public string targetAddress;
	public Text statusText;	
	
	public int controlIndex
	{
		get;
		set;
	}
	public Dropdown controlList;
	
    // Start is called before the first frame update
    void Start()
    {
		isConnecting = false;
		sensorList.interactable = false;
		
		SetScanList(RabboniConsole.instance.rabboniList);
		RabboniConsole.instance.AddConnection(this);
		sensorList.interactable = true;
		
		connectBtn.gameObject.SetActive(true);
		disconnectBtn.gameObject.SetActive(false);
		
		InitControlList();
    }

	public void InitControlList()
	{
		List<string> controls = new List<string>();
		
		int count = RabboniConsole.instance.rabboniControls.Count;
		for(int i =0; i<count; i++)
		{
			controls.Add(RabboniConsole.instance.rabboniControls[i].description);
		}
		
		controlList.ClearOptions();
		controlList.AddOptions(controls);
	}
	

	public void SetScanList(List<string> rabonniList)
	{
		if(isConnecting) return;
		
		myRabonniList = rabonniList;
		sensorList.ClearOptions();
		
		if(myRabonniList.Count > 0)
		{
			if(!sensorList.gameObject.activeInHierarchy)
			{
				sensorList.gameObject.SetActive(true);
			}
			if(scanHint.activeInHierarchy)
			{
				scanHint.SetActive(false);
			}
			if(!connectBtn.interactable)
			{
				connectBtn.interactable = true;
			}
		
			sensorList.AddOptions(myRabonniList);
		
		
			if(myRabonniList.Count > 0 && targetAddress == "")
			{
				Select(0);
			}
		}
		else
		{
			if(sensorList.gameObject.activeInHierarchy)
			{
				sensorList.gameObject.SetActive(false);
			}
			if(!scanHint.activeInHierarchy)
			{
				scanHint.SetActive(true);
			}
			if(connectBtn.interactable)
			{
				connectBtn.interactable = false;
			}
		}
	}
	
	public void Select(int val)
	{
		selectIndex = val;
		targetAddress = myRabonniList[selectIndex];
		connectBtn.interactable = sensorList.interactable;
	}
	
	public void Connect()
	{
		statusText.text = "連線狀態: 正在建立連線...";
		isConnecting = true;
		sensorList.interactable = false;
		connectBtn.interactable = false;
		

		BluetoothLEHardwareInterface.ConnectToPeripheral (targetAddress, null, null, (address, serviceUUID, characteristicUUID) => {

			if (IsEqual (serviceUUID, ServiceUUID))
			{
				if (IsEqual (characteristicUUID, Characteristic))
				{
					statusText.text = "連線狀態: 成功建立連線";
					connectBtn.gameObject.SetActive(false);
					disconnectBtn.gameObject.SetActive(true);
					
					Invoke("Subscribe", 2f);
				}
			}
		}, (disconnectedAddress) => {
			BluetoothLEHardwareInterface.Log ("Device disconnected: " + disconnectedAddress);
			
			statusText.text = "連線狀態: 連線中斷";
			isConnecting = false;
			SetScanList(RabboniConsole.instance.rabboniList);
			sensorList.interactable = true;
			connectBtn.gameObject.SetActive(true);
			disconnectBtn.gameObject.SetActive(false);
		});
	}
	
	void OnDestroy()
	{
		if(isConnecting)
		{
			Disconnect();
		}
	}
	
	public void Disconnect()
	{
		BluetoothLEHardwareInterface.DisconnectPeripheral (targetAddress, (disconnectedAddress) => {
			
		});
	}
	
	Vector3 acc = Vector3.zero;
	public void Subscribe()
	{
		statusText.text = "連線狀態: 連線中";
		
		BluetoothLEHardwareInterface.SubscribeCharacteristicWithDeviceAddress (targetAddress, ServiceUUID, Characteristic, null, (address, characteristicUUID, bytes) => {
			string data = ByteArrayToString(bytes);
			
			int[] dataElement = new int[6];
			
			for(int i=0; i < 6; i++)
			{
				string tempHex = data.Substring(i*4, 4);
				short tempVal = System.Convert.ToInt16(tempHex, 16);
				dataElement[i] = tempVal;
			}
			acc.x = dataElement[0];
			acc.y = dataElement[1];
			acc.z = dataElement[2];
			
			RabboniConsole.instance.rabboniControls[controlIndex].Sync(acc);
			
		});
	}
	
	public void RemoveConnection()
	{
		RabboniConsole.instance.RemoveConnection(this);
		Destroy(gameObject);
	}
	
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
}
