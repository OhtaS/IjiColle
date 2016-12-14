using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Navigator;
using Ijin;
using Common;

namespace Crane{
	public enum State{
		Ready,
		MoveLeft,
		MoveRight,
		Stop,
		Open,
		Fall,
		Close,
		Rise,
		WaitingAnswer,
		MoveCorrect,
		MoveIncorrect,
		WaitingJudgement,
		Return,
		Finish}
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
		bool isMoving;
		bool isOpening;
		bool isClosing;
		bool isAnsweredCorrect;		
		public int remainingTrialCount;
		public State state;
		public bool isCatched;
		public Collider2D reachedObj;

		void Start(){
			state = State.Ready;
			isCatched = false;
			isOpening = false;
			isClosing = false;
			isMoving = false;
			isAnsweredCorrect = true;
			default_position = transform.position;
			arm_l = transform.GetChild(0);
			arm_r = transform.GetChild(1);
			open_angle_l = new Vector3(arm_l.eulerAngles.x, arm_l.eulerAngles.y, arm_l.eulerAngles.z + 150);
			open_angle_r = new Vector3(arm_r.eulerAngles.x, arm_r.eulerAngles.y, arm_r.eulerAngles.z + 150);
			close_angle_l = arm_l.eulerAngles;
			close_angle_r = arm_r.eulerAngles;
			correctBox_position = GameObject.Find("CorrectBox").transform.localPosition;
			incorrectBox_position = GameObject.Find("IncorrectBox").transform.localPosition;
			remainingTrialCount = 3;
		}

		public void Fall(){
			if (reachedObj == null && transform.localPosition.y >= -2.0f){
				transform.position = new Vector3(transform.position.x, transform.position.y - 0.02f, transform.position.z);
			} else{
				state = State.Close;
			}
		}

		public IEnumerator CloseArms(State next_state){
			if (isClosing){
				yield break;
			}
			isClosing = true;

			while (Mathf.Abs(Mathf.DeltaAngle(arm_l.eulerAngles.z, close_angle_l.z)) >= 0.1f
			       || Mathf.Abs(Mathf.DeltaAngle(arm_r.eulerAngles.z, close_angle_r.z)) >= 0.1f){
				arm_l.Rotate(0f, 0f, 1f);
				arm_r.Rotate(0f, 0f, 1f);
				yield return null;
			}

			state = next_state;
			isClosing = false;
		}

		//		public void CloseArms(State next_state){
		//			if (Mathf.Abs(Mathf.DeltaAngle(arm_l.eulerAngles.z, close_angle_l.z)) < 0.1f
		//			    && Mathf.Abs(Mathf.DeltaAngle(arm_r.eulerAngles.z, close_angle_r.z)) < 0.1f){
		//			} else{
		//
		//			}
		//		}



		public void Rise(){
			if (transform.position.y >= default_position.y){
				if (isCatched == true){
					state = State.WaitingAnswer;
				} else{
					state = State.Return;
				}				
			} else{
				transform.position = new Vector3(transform.position.x, transform.position.y + 0.02f, transform.position.z);
			}
		}

		public IEnumerator OpenArms(State next_state){
			if (isOpening){
				yield break;
			}
			isOpening = true;

			while (Mathf.DeltaAngle(arm_l.eulerAngles.z, open_angle_l.z) >= 0.1f
			       && Mathf.DeltaAngle(arm_r.eulerAngles.z, open_angle_r.z) >= 0.1f){
				arm_l.Rotate(0f, 0f, -1f);
				arm_r.Rotate(0f, 0f, -1f);
				yield return null;
			}
			reachedObj = null;
			state = next_state;
			isOpening = false;
		}

		public void MoveLeft(){
			transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z);
		}

		public void MoveRight(){
			transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, transform.position.z);
		}

		public void StopMovement(){
			state = State.Open;
			remainingTrialCount--;
		}

		public IEnumerator MoveCorrect(){
			if (isMoving){
				yield break;
			}
			isMoving = true;

			while (transform.localPosition.x > correctBox_position.x){
				transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z);
				yield return null;
			}

			yield return new WaitForSeconds(1.0f);
			yield return OpenArms(State.WaitingJudgement);
			isMoving = false;
		}

		public IEnumerator MoveIncorrect(){
			if (isMoving){
				yield break;
			}
			isMoving = true;

			while (transform.localPosition.x < incorrectBox_position.x){
				transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, transform.position.z);
				yield return null;
			}

			yield return new WaitForSeconds(1.0f);
			yield return OpenArms(State.WaitingJudgement);
			isMoving = false;
		}

		public void WaitAnswer(){
			StartCoroutine(GameObject.Find("Ochimusha").GetComponent<Ochimusha>().Question());
		}

		public IEnumerator WaitJudgement(Answer player_answer){
			if (isMoving){
				yield break;
			}

			isMoving = true;
			yield return new WaitForSeconds(0.5f);
			yield return GameObject.Find("/Main Camera").GetComponent<CameraManager>().ZoomInHusuma();
			isAnsweredCorrect = GameObject.Find("Ochimusha").GetComponent<Ochimusha>().Judge(player_answer);
			yield return new WaitForSeconds(2.0f);
			StartCoroutine(GameObject.Find("/Object/CraneGameMachine/Husuma").GetComponent<Husuma>().OpenHusuma());
			yield return new WaitForSeconds(0.7f);

			if (isAnsweredCorrect == true){
				yield return StartCoroutine(Common.MySceneManager.LoadSuccessScene());
			} else{
				Ready();
				yield return StartCoroutine(Common.MySceneManager.LoadFailureScene());
			}
			GameObject.Find("/Main Camera").GetComponent<CameraManager>().ZoomOut();
			GameObject.Find("/Object/CraneGameMachine/Husuma").GetComponent<Husuma>().CloseHusuma();
			state = State.Return;
			isMoving = false;
		}

		public IEnumerator ReturnToBase(){
			if (isMoving){
				yield break;
			}
			isMoving = true;

			yield return new WaitForSeconds(0.2f);
			yield return CloseArms(state);


			while (Mathf.Abs(transform.position.x - default_position.x) >= 0.02){
				if (transform.position.x - default_position.x >= 0){
					transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z);
				} else{
					transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, transform.position.z);
				}
				yield return null;
			}
			if (remainingTrialCount > 0){
				state = State.Ready;
			} else{
				state = State.Finish;
			}
			isMoving = false;
		}

		public void Ready(){
			GameObject.Find("Ochimusha").GetComponent<Ochimusha>().ResponeIjin();
		}
	}
}