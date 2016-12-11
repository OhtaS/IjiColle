using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Ijin;

namespace Crane{
	public class CraneStateMachine : MonoBehaviour{
		Crane crane;
		ObjectDestroyer objectDestroyer;
		public Ijin.Answer player_answer;
		// Use this for initialization
		void Start(){
			crane = gameObject.GetComponent<Crane>();
			objectDestroyer = gameObject.GetComponent<ObjectDestroyer>();
			player_answer = Ijin.Answer.Unanswered;
			StartCoroutine(crane.CloseArms(crane.state));
		}
	
		// Update is called once per frame
		void Update(){
			GameObject.Find("/Canvas/TrialCount").GetComponent<UnityEngine.UI.Text>().text = crane.remainingTrialCount.ToString();
			switch(crane.state){
				case State.Ready:
					objectDestroyer.ObstacleDestroy();
					player_answer = Ijin.Answer.Unanswered;
					if (GameObject.Find("/Object/CraneGameMachine/Buttons/LeftButton").GetComponent<BoxCollider2D>().enabled == false
					    || GameObject.Find("/Object/CraneGameMachine/Buttons/RightButton").GetComponent<BoxCollider2D>().enabled == false){
						GameObject.Find("/Object/CraneGameMachine/Buttons/LeftButton").GetComponent<BoxCollider2D>().enabled = true;
						GameObject.Find("/Object/CraneGameMachine/Buttons/RightButton").GetComponent<BoxCollider2D>().enabled = true;
					}
					if (GameObject.Find("/Object/CraneGameMachine/Buttons/RightButton").GetComponent<IncorrectButton>() != null){
						DestroyObject(GameObject.Find("/Object/CraneGameMachine/Buttons/RightButton").GetComponent<IncorrectButton>());
						GameObject.Find("/Object/CraneGameMachine/Buttons/RightButton").AddComponent<RightButton>();
					}
					if (GameObject.Find("/Object/CraneGameMachine/Buttons/LeftButton").GetComponent<CorrectButton>() != null){
						DestroyObject(GameObject.Find("/Object/CraneGameMachine/Buttons/LeftButton").GetComponent<CorrectButton>());
						GameObject.Find("/Object/CraneGameMachine/Buttons/LeftButton").AddComponent<LeftButton>();
					}
				break;

				case State.MoveLeft:
					crane.MoveLeft();
				break;

				case State.MoveRight:
					crane.MoveRight();
				break;

				case State.Stop:
					crane.StopMovement();
				break;

				case State.Open:
					if (GameObject.Find("/Object/CraneGameMachine/Buttons/LeftButton").GetComponent<BoxCollider2D>().enabled == true
					    || GameObject.Find("/Object/CraneGameMachine/Buttons/RightButton").GetComponent<BoxCollider2D>().enabled == true){
						GameObject.Find("/Object/CraneGameMachine/Buttons/LeftButton").GetComponent<BoxCollider2D>().enabled = false;
						GameObject.Find("/Object/CraneGameMachine/Buttons/RightButton").GetComponent<BoxCollider2D>().enabled = false;
					}
					StartCoroutine(crane.OpenArms(State.Fall));
				break;

				case State.Fall:
					crane.Fall();
				break;

				case State.Close:
					StartCoroutine(crane.CloseArms(State.Rise));
				break;

				case State.Rise:
					crane.Rise();
				break;

				case State.WaitingAnswer:
					objectDestroyer.ObstacleDestroy();
					crane.WaitAnswer();
					if (GameObject.Find("/Object/CraneGameMachine/Buttons/LeftButton").GetComponent<BoxCollider2D>().enabled == false
					    || GameObject.Find("/Object/CraneGameMachine/Buttons/RightButton").GetComponent<BoxCollider2D>().enabled == false){
						GameObject.Find("/Object/CraneGameMachine/Buttons/LeftButton").GetComponent<BoxCollider2D>().enabled = true;
						GameObject.Find("/Object/CraneGameMachine/Buttons/RightButton").GetComponent<BoxCollider2D>().enabled = true;
					}
					if (GameObject.Find("/Object/CraneGameMachine/Buttons/RightButton").GetComponent<RightButton>()){
						DestroyObject(GameObject.Find("/Object/CraneGameMachine/Buttons/RightButton").GetComponent<RightButton>());
						GameObject.Find("/Object/CraneGameMachine/Buttons/RightButton").AddComponent<IncorrectButton>();
					}
					if (GameObject.Find("/Object/CraneGameMachine/Buttons/LeftButton").GetComponent<LeftButton>()){
						DestroyObject(GameObject.Find("/Object/CraneGameMachine/Buttons/LeftButton").GetComponent<LeftButton>());
						GameObject.Find("/Object/CraneGameMachine/Buttons/LeftButton").AddComponent<CorrectButton>();
					}
				break;

				case State.MoveCorrect:
					if (SceneManager.GetSceneByName("Question").isLoaded == true){
						UnityEngine.SceneManagement.SceneManager.UnloadScene("Question");
						player_answer = Ijin.Answer.Correct;
					}
					StartCoroutine(crane.MoveCorrect());
				break;

				case State.MoveIncorrect:
					if (SceneManager.GetSceneByName("Question").isLoaded == true){
						UnityEngine.SceneManagement.SceneManager.UnloadScene("Question");
						player_answer = Ijin.Answer.Incorrect;
					}
					StartCoroutine(crane.MoveIncorrect());
				break;

				case State.WaitingJudgement:
					if (GameObject.Find("/Object/CraneGameMachine/Buttons/LeftButton").GetComponent<BoxCollider2D>().enabled == true
					    || GameObject.Find("/Object/CraneGameMachine/Buttons/RightButton").GetComponent<BoxCollider2D>().enabled == true){
						GameObject.Find("/Object/CraneGameMachine/Buttons/LeftButton").GetComponent<BoxCollider2D>().enabled = false;
						GameObject.Find("/Object/CraneGameMachine/Buttons/RightButton").GetComponent<BoxCollider2D>().enabled = false;
					}
					crane.WaitJudgement(player_answer);
				break;

				case State.Return:
					objectDestroyer.ObstacleDestroy();
					StartCoroutine(crane.ReturnToBase()); 
				break;

				case  State.Finish:
					Debug.Log("Finish");
				break;
			}
		}
	}
}