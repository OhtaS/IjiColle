using UnityEngine;
using System.Collections;
using Ijin;

namespace Crane{
	public class CraneStateMachine : MonoBehaviour{
		Crane crane;
		ObjectDestroyer objectDestroyer;
		Answer player_answer;
		// Use this for initialization
		void Start(){
			crane = gameObject.GetComponent<Crane>();
			objectDestroyer = gameObject.GetComponent<ObjectDestroyer>();
			player_answer = Answer.Unanswered;
		}
	
		// Update is called once per frame
		void Update(){
			if (Input.GetKey(KeyCode.Space) && crane.state == State.MoveX){
				crane.state = State.Open;
			}
			if (player_answer == Answer.Unanswered && Input.GetKeyUp(KeyCode.LeftArrow)){
				player_answer = Answer.Correct;
			} else if (player_answer == Answer.Unanswered && Input.GetKeyUp(KeyCode.RightArrow)){
				player_answer = Answer.Incorrect;
			}

			switch(crane.state){
				case State.Ready:
					objectDestroyer.ObstacleDestroy();
					crane.CloseArms(crane.state);
					player_answer = Answer.Unanswered;
				break;

				case State.Open:
					crane.OpenArms(State.Fall);
				break;

				case State.Fall:
					crane.Fall();
				break;

				case State.Close:
					crane.CloseArms(State.Rise);
				break;

				case State.Rise:
					crane.Rise();
				break;

				case State.WaitingAnswer:
					objectDestroyer.ObstacleDestroy();
					crane.WaitAnswer(player_answer);
				break;

				case State.WaitingJudgement:
					crane.WaitJudgement(player_answer);
				break;

				case State.Return:
					objectDestroyer.ObstacleDestroy();
					crane.ReturnToBase();
				break;
			}
		}
	}
}