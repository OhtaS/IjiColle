using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common{
	public class DataManager : MonoBehaviour{
		const string jsonSavePath = "Assets/Resources/Save/SavedCharacterList.json";

		private SerializableSaveData saveData;

		void Start(){
			saveData = LoadData();
			DontDestroyOnLoad(gameObject);
		}

		public void SaveData(){
			#if UNITY_IPHONE
				Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
			#endif
			string json = JsonUtility.ToJson(saveData);
			Debug.Log(json);
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(jsonSavePath);
			bf.Serialize(file, json);
			file.Close();
		}

		public SerializableSaveData LoadData(){
			#if UNITY_IPHONE
				Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
			#endif
			if (System.IO.File.Exists(jsonSavePath) == false){
				Debug.Log("file not found");
				return new Common.SerializableSaveData();
			}
			BinaryFormatter bf = new BinaryFormatter(); 
			FileStream file = File.Open(jsonSavePath, FileMode.Open); 
			string json = (string)bf.Deserialize(file);
			file.Close();
			SerializableSaveData loadData = JsonUtility.FromJson<SerializableSaveData>(json);
			return loadData;
		}

		public void AddIjin(string name){
			if (saveData.ijinList.Exists(x => x.Equals(name)) == false){
				saveData.ijinList.Add(name);
			}
		}

		public List<string> SavedIjinList{
			get{ return saveData.ijinList; }
		}
	}
}
