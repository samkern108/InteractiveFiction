using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour {

	float speed = 1;
	float turnSpeedDampener = 20;
	float angle = Mathf.PI/2;
	float updateTicker = 0;
	float updateMaxTicks = 2;

	Vector2 moveVector = Vector2.zero;
	
	void Start () {
		Player.position = new Global.Position (new Vector2(0,0), new Vector2(0,0));
	}

	void FixedUpdate () {
		//Vertical   : Move forward/backwards
		//Horizontal : Turn left/right

		//Come up with a more intelligent way of moderating framerate.
		/*if (updateTicker >= updateMaxTicks) {
			updateTicker = 0;
		} else {
			updateTicker++;
			return;
		}*/

		moveVector = new Vector2 (Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
	
		Vector2 newPosition = Player.position.posV;

		if (moveVector.x < 0) {
			newPosition = Player.position.MoveWithSpeed(-speed);
		} else if (moveVector.x > 0) {
			newPosition = Player.position.MoveWithSpeed(speed);
		}

		if (newPosition != Player.position.posV && ProcessMovement(newPosition)) {
			Player.position.posV = newPosition;
			SendMovementNotificationOnTimer(NotificationSystem.Notification.playerMoved);
		}

		if (moveVector.y < 0) {
			angle += (speed / turnSpeedDampener);
			if (angle > 2 * Mathf.PI) {
				angle -= 2 * Mathf.PI;
			}
		} else if (moveVector.y > 0) {
			angle -= (speed / turnSpeedDampener);
			if (angle < 0) {
				angle += 2*Mathf.PI;
			}
		}

		if (moveVector.y != 0) {
			Player.position.dirV = new Vector2(Mathf.Cos (angle), Mathf.Sin (angle));
			SendMovementNotificationOnTimer(NotificationSystem.Notification.playerTurned);
		}
	}

	private void SendMovementNotificationOnTimer(NotificationSystem.Notification notification) 
	{
		NotificationSystem.instance.SendNotificationWithValue(notification, Player.position);
	}

	private bool ProcessMovement(Vector2 newPosition)
	{
		return true;//ActiveRoomManager.DetectCollision (newPosition);
	}
}
