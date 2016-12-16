using UnityEngine;
using System.Collections;

public class ResetButton : AbstractButton{
	protected override void ActionByPushed(){
		GameObject.Find("DataManager").GetComponent<Common.SaveDataManager>().InitializeIjinList();
	}
}
