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
	}
}