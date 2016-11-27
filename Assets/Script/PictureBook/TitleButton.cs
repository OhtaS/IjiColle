using UnityEngine;
using System.Collections;

namespace PictureBook{
	public class TitleButton : AbstractButton{
		protected override void ActionByPushed(){
			StartCoroutine(Common.MySceneManager.LoadScene("Title"));
		}
	}
}