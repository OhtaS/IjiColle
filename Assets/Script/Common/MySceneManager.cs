using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Common{
	public static class MySceneManager{
		static bool isLoading = false;

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
			Scene currentScene = SceneManager.GetActiveScene();
			yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
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
			SceneManager.UnloadScene(SceneManager.GetSceneAt(1));
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
			SceneManager.UnloadScene(SceneManager.GetSceneAt(1));
		}

		public static IEnumerator LoadStageSuccessScene(){
			if (isLoading){
				yield break;
			}
			isLoading = true;
			Scene currentScene = SceneManager.GetActiveScene();
			yield return SceneManager.LoadSceneAsync("StageSuccess", LoadSceneMode.Additive);
			yield return new WaitForSecondsRealtime(3.0f);
			yield return SceneManager.LoadSceneAsync("Title", LoadSceneMode.Additive);
			isLoading = false;
			SceneManager.UnloadScene("StageSuccess");
			SceneManager.UnloadScene(currentScene);
		}

		public static IEnumerator LoadStageFailureScene(){
			if (isLoading){
				yield break;
			}
			isLoading = true;
			Scene currentScene = SceneManager.GetActiveScene();
			yield return SceneManager.LoadSceneAsync("StageFailure", LoadSceneMode.Additive);
			yield return new WaitForSecondsRealtime(3.0f);
			yield return SceneManager.LoadSceneAsync("Title", LoadSceneMode.Additive);
			isLoading = false;
			SceneManager.UnloadScene("StageFailure");
			SceneManager.UnloadScene(currentScene);
		}
	}
}