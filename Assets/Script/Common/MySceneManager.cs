using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Common{
	public static class MySceneManager{
		static bool isLoading = false;
		static string PlayedStand = "MultipleChoice2";

		/// <summary>
		/// シーンのロード。ロードが完了するまで待機。
		/// </summary>
		/// <returns>The scene.</returns>
		/// <param name="sceneName">Scene name.</param>

		public static IEnumerator LoadScene(string sceneName){
			if (isLoading){
				yield break;
			}
			isLoading = true;
			// Scene currentScene = SceneManager.GetActiveScene();
			yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
			isLoading = false;
			while(SceneManager.sceneCount != 1){
				Debug.Log(SceneManager.sceneCount);
				Scene currentScene = SceneManager.GetActiveScene();
				SceneManager.UnloadScene(currentScene);
			}
		}

		public static IEnumerator LoadStandScene(string standName){
			if(standName == "Replay"){
				standName = PlayedStand;
			}else{
				PlayedStand = standName;
			}
			if (isLoading){
				yield break;
			}
			isLoading = true;
			Scene currentScene = SceneManager.GetActiveScene();
			yield return SceneManager.LoadSceneAsync(standName, LoadSceneMode.Additive);
			yield return SceneManager.LoadSceneAsync("MultipleChoiceCrane", LoadSceneMode.Additive);
			isLoading = false;
			SceneManager.UnloadScene(currentScene);
		}

		public static IEnumerator LoadSuccessScene(){
			if (isLoading){
				yield break;
			}
			isLoading = true;
			Scene currentScene = SceneManager.GetActiveScene();
			yield return SceneManager.LoadSceneAsync("Success", LoadSceneMode.Additive);
			yield return new WaitForSecondsRealtime(1.0f);
			isLoading = false;
			SceneManager.UnloadScene("Success");
		}

		public static IEnumerator LoadFailureScene(){
			if (isLoading){
				yield break;
			}
			isLoading = true;
			Scene currentScene = SceneManager.GetActiveScene();
			yield return SceneManager.LoadSceneAsync("Failure", LoadSceneMode.Additive);
			yield return new WaitForSecondsRealtime(1.0f);
			isLoading = false;
			SceneManager.UnloadScene("Failure");
		}

		public static IEnumerator LoadStageSuccessScene(){
			if (isLoading){
				yield break;
			}
			isLoading = true;
			// Scene currentScene = SceneManager.GetActiveScene();
			yield return SceneManager.LoadSceneAsync("StageSuccess", LoadSceneMode.Additive);
			yield return new WaitForSecondsRealtime(3.0f);
			yield return SceneManager.LoadSceneAsync("Continue", LoadSceneMode.Additive);
			isLoading = false;
			SceneManager.UnloadScene("StageSuccess");
			while(SceneManager.sceneCount != 1){
				Debug.Log(SceneManager.sceneCount);
				Scene currentScene = SceneManager.GetActiveScene();
				SceneManager.UnloadScene(currentScene);
			}
		}

		public static IEnumerator LoadStageFailureScene(){
			if (isLoading){
				yield break;
			}
			isLoading = true;
			// Scene currentScene = SceneManager.GetActiveScene();
			yield return SceneManager.LoadSceneAsync("StageFailure", LoadSceneMode.Additive);
			yield return new WaitForSecondsRealtime(3.0f);
			yield return SceneManager.LoadSceneAsync("Continue", LoadSceneMode.Additive);
			isLoading = false;
			SceneManager.UnloadScene("StageFailure");
			while(SceneManager.sceneCount != 1){
				Debug.Log(SceneManager.sceneCount);
				Scene currentScene = SceneManager.GetActiveScene();
				SceneManager.UnloadScene(currentScene);
			}
		}
	}
}