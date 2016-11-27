using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class Test : MonoBehaviour {
	private int count;
	private string SavedData;
	TestData data = new TestData();

	[Serializable]
	public class TestData{
		public int SavedCount;
	}

	void Start () {
		ReadSavedData();
		GetComponent<Text>().text = count.ToString();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.S)){
			WriteData();
		}
		if (Input.GetKeyDown(KeyCode.C)){
			count = 0;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)){
			count -= 1;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			count += 1;
		}
		GetComponent<Text>().text = count.ToString();
	}

	void ReadSavedData () {
		StreamReader sr = new StreamReader(Application.dataPath + "/StreamingAssets/" + "LogData.json",true);
		SavedData = sr.ReadLine();
		sr.Close();
		TestData data = JsonUtility.FromJson<TestData>(SavedData);
		count = data.SavedCount;
		Debug.Log("Read  " + SavedData);
	}

	void WriteData () {
		data.SavedCount = count;
		string json = JsonUtility.ToJson(data);
		StreamWriter sw = new StreamWriter(Application.dataPath + "/StreamingAssets/" + "LogData.json", false);
		sw.WriteLine(json);
		sw.Flush();
		sw.Close();
		Debug.Log("Write  " + json);
	}
}