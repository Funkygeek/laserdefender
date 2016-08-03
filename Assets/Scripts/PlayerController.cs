using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 15.0f; // The relative movement speed from left to right

	// variables for play area range..
	private Vector2 leftSide, rightSide;
	public float offset = 0.5f;



	// Use this for initialization
	void Start () {

		// Need to determine the left and right constaint so the player doesn't dissapear off the playfield
		// user the camera to find the left
		float distance = transform.position.z - Camera.main.transform.position.z;
		leftSide = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		rightSide = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));

		Debug.Log ("Left Side = " + leftSide);
		Debug.Log ("Right Side = " + rightSide);

	}

	Vector3 movePlayerToPosition(Vector3 direction)
	{
		Vector3 newPosition = gameObject.transform.position + (direction * speed * Time.deltaTime);

		// We want the edge of the player to not go over the side.  So the position is based on a center point
		// of the player width... So we need to chop it in half to get the offset


		newPosition.x = Mathf.Clamp (newPosition.x, leftSide.x+offset, rightSide.x-offset);
		return newPosition;
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKey (KeyCode.RightArrow)) {
			// Move right
			gameObject.transform.position= movePlayerToPosition (Vector3.right);
		


		}

	

		if(Input.GetKey (KeyCode.LeftArrow)) {
			// Move left
			gameObject.transform.position= movePlayerToPosition (Vector3.left);
		}


	}
}
