﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Crane{
	public enum AnswerState{
		Unanswered,
		Correct,
		Incorrect}
	;

	public enum State{
		Ready,
		MoveX,
		Open,
		Fall,
		Close,
		Rise,
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
		public static State state;
		public static AnswerState answerState;
		public bool isCatched;

		void Start(){
			state = State.Ready;
			answerState = AnswerState.Unanswered;
			isCatched = false;
			default_position = transform.position;
			arm_l = transform.GetChild(0);
			arm_r = transform.GetChild(1);
			open_angle_l = new Vector3(arm_l.eulerAngles.x, arm_l.eulerAngles.y, arm_l.eulerAngles.z + 40);
			open_angle_r = new Vector3(arm_r.eulerAngles.x, arm_r.eulerAngles.y, arm_r.eulerAngles.z + 40);
			close_angle_l = arm_l.eulerAngles;
			close_angle_r = arm_r.eulerAngles;
		}

		void Update(){
			PlayMultipleChoice();
		}

		void PlayMultipleChoice(){
			if (Input.GetKey(KeyCode.Space) && state == State.MoveX){
				state = State.Open;
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

				case State.WaitingJudgement:

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
					state = State.WaitingJudgement;
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

		void MoveWrongAnswer(){

		}

		void MoveCorrectAnswer(){

		}
	}
}