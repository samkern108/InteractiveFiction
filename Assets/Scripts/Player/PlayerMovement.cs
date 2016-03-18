using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	const float speed = 10f;
	const float turnSpeed = 2f;
	float angle = 0;
	const float twoPI = Mathf.PI * 2;

	Vector2 moveVector;
	private Position position;

	bool sendNotification = false;
	Vector2 newPosition;

	void Update () 
	{
		//Vertical   : Move forward/backwards
		//Horizontal : Turn left/right
		moveVector = new Vector2 (Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

		newPosition = position.posV;

		if (moveVector.y != 0) {
			angle += (-moveVector.y * (turnSpeed  * Time.deltaTime));
			angle %= (twoPI);
			if (angle < 0) {
				angle += twoPI;
			}
			
			position.RotateToAngle(angle);
			sendNotification = true;
		}

		if (moveVector.x != 0) {
			bool hit = Physics2D.Raycast (transform.position, Mathf.Sign(moveVector.x) * position.dirV, 5, 1 << LayerMask.NameToLayer ("Impassable"));
			if (!hit) {
				position.MoveWithSpeed((speed * Time.deltaTime) * moveVector.x);
			}

			if(ActiveRoomManager.self.PlayerInsideRoom (newPosition)) {
				sendNotification = true;
				transform.position = new Vector3(newPosition.x, newPosition.y, -7);
			}
		}

		if (sendNotification) {
			NotificationSystem.instance.SendNotificationWithValue(Notification.PlayerMoved, position);
			sendNotification = false;
		}
	}
}
