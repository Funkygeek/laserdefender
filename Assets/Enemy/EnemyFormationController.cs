using UnityEngine;
using System.Collections;

public class EnemyFormationController : MonoBehaviour {
	public float width=10.0f;
	public float height=5.0f;
	public GameObject EnemyPrefab;

	private Vector2 leftSide, rightSide;
	private float offset;

	// Variables for the left right movement
	private bool movingRight = true;
	public float speed = 5;

	// Use this for initialization
	void Start () {
		offset = (width-1.0f) / 2;
		// Need to determine the left and right constaint so the player doesn't dissapear off the playfield
		// user the camera to find the left
		float distance = transform.position.z - Camera.main.transform.position.z;
		leftSide = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		rightSide = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));

		// We will instatiate the enemy by going through the positional items in the Formation Array
		foreach (Transform child in transform) {
			GameObject enemy = GameObject.Instantiate (EnemyPrefab,child.position, Quaternion.identity,child) as GameObject;
		}
	
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube (transform.position, new Vector3(width,height,0));
	}

	Vector3 moveFormationToPosition(Vector3 direction)

	{
		Vector3 newPosition = gameObject.transform.position + (direction * speed * Time.deltaTime);

		// We want the edge of the player to not go over the side.  So the position is based on a center point
		// of the player width... So we need to chop it in half to get the offset


		newPosition.x = Mathf.Clamp (newPosition.x, leftSide.x+offset, rightSide.x-offset);
		if (newPosition.x == gameObject.transform.position.x) {
			movingRight = !movingRight;
		}
		return newPosition;
	}

	// Update is called once per frame
	void Update () {
		if (movingRight) {
			gameObject.transform.position = moveFormationToPosition (Vector3.right);
		} else {
			gameObject.transform.position = moveFormationToPosition (Vector3.left);
		}
	}
}
