using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Navigator;
using Ijin;

namespace Crane{
	public enum State{
		Ready,
		MoveX,
		Open,
		Fall,
		Close,
		Rise,
		WaitingAnswer,
		WaitingJudgement,
		Return}
	;

	public class Crane : MonoBehaviour{
		Transform arm_l;
		Transform arm_r;
		Vector3 open_angle_l;
		Vector3 open_angle_r;
		Vector3 close_angle_l;
		Vector3 close_angle_r;
		Vector3 default_position;
		Vector3 correctBox_position;
		Vector3 incorrectBox_position;
		public static State state;
		public Answer player_answer;
		public bool isCatched;

		void Start(){
			state = State.Ready;
			player_answer = Answer.Unanswered;
			isCatched = false;
			default_position = transform.position;
			arm_l = transform.GetChild(0);
			arm_r = transform.GetChild(1);
			open_angle_l = new Vector3(arm_l.eulerAngles.x, arm_l.eulerAngles.y, arm_l.eulerAngles.z + 40);
			open_angle_r = new Vector3(arm_r.eulerAngles.x, arm_r.eulerAngles.y, arm_r.eulerAngles.z + 40);
			close_angle_l = arm_l.eulerAngles;
			close_angle_r = arm_r.eulerAngles;
			correctBox_position = GameObject.Find("CorrectBox").transform.localPosition;
			incorrectBox_position = GameObject.Find("IncorrectBox").transform.localPosition;
		}

		void Update(){
			PlayMultipleChoice();
		}

		void PlayMultipleChoice(){
			if (Input.GetKey(KeyCode.Space) && state == State.MoveX){
				state = State.Open;
			}
			if (Input.GetKeyUp(KeyCode.LeftArrow)){
				player_answer = Answer.Correct;
			} else if (Input.GetKeyUp(KeyCode.RightArrow)){
				player_answer = Answer.Incorrect;
			}

			switch(state){
				case State.Ready:
					CloseArms(state);
				break;

				case State.Open:
					OpenArms(State.Fall);
				break;

				case State.Fall:
					Fall();
				break;

				case State.Close:
					CloseArms(State.Rise);
				break;

				case State.Rise:
					Rise();
				break;

				case State.WaitingAnswer:
					GameObject.Find("Ochimusha").GetComponent<Ochimusha>().Question();
					if (player_answer == Answer.Correct){
						MoveCorrect();
					} else if (player_answer == Answer.Incorrect){
						MoveIncorrect();
					}
				break;

				case State.WaitingJudgement:
					if (GameObject.Find("Ochimusha").GetComponent<Ochimusha>().Judge(player_answer) == false){
						GameObject.Find("Ochimusha").GetComponent<Ochimusha>().ResponeIjin();
					} else{
					}
					if (SceneManager.GetSceneByName("Question").isLoaded == true){
						GameObject.Find("Button_left").GetComponent<BoxCollider2D>().enabled = true;
						GameObject.Find("Button_right").GetComponent<BoxCollider2D>().enabled = true;
						UnityEngine.SceneManagement.SceneManager.UnloadScene("Question");
					}
					state = State.Return;
				break;

				case State.Return:
					ReturnToBase();
				break;
			}
		}

		void Fall(){
			if (transform.position.y >= default_position.y - 0.5f){
				transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
			} else{
				state = State.Close;
			}
		}

		void CloseArms(State next_state){
			if (Mathf.Abs(Mathf.DeltaAngle(arm_l.eulerAngles.z, close_angle_l.z)) < 0.1f && Mathf.Abs(Mathf.DeltaAngle(arm_r.eulerAngles.z,
			                                                                                                           close_angle_r.z)) < 0.1f){
				state = next_state;
			} else{
				arm_l.Rotate(0f, 0f, -1f);
				arm_r.Rotate(0f, 0f, -1f);
			}
		}

		void Rise(){
			if (transform.position.y >= default_position.y){
				if (isCatched == true){
					state = State.WaitingAnswer;
				} else{
					state = State.Return;
				}				
			} else{
				transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
			}
		}

		void ReturnToBase(){
			if (transform.position.x - default_position.x > 0.01){
				transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
			} else if (transform.position.x - default_position.x < -0.01){
				transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
			} else{
				OpenArms(State.Ready);
			}
		}

		void OpenArms(State next_state){
			if (Mathf.DeltaAngle(arm_l.eulerAngles.z, open_angle_l.z) < 0.1f && Mathf.DeltaAngle(arm_r.eulerAngles.z,
			                                                                                     open_angle_r.z) < 0.1f){
				state = next_state;
			} else{
				arm_l.Rotate(0f, 0f, 1f);
				arm_r.Rotate(0f, 0f, 1f);
			}
		}

		public IEnumerator MoveLeft(){
			if (state != State.Ready){
				yield break;
			}
			while (true){
				transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
				yield return null;
			}
		}

		public IEnumerator MoveRight(){
			if (state != State.Ready){
				yield break;
			}
			while (true){
				transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
				yield return null;
			}
		}

		public void StopMovement(){
			state = State.Open;
		}

		void MoveCorrect(){
			if (transform.localPosition.x > correctBox_position.x){
				transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
			} else{
				OpenArms(State.WaitingJudgement);
			}
		}

		void MoveIncorrect(){
			if (transform.localPosition.x < incorrectBox_position.x){
				transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
			} else{
				OpenArms(State.WaitingJudgement);
			}
		}
	}
}