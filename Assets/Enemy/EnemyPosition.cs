using UnityEngine;
using System.Collections;

public class EnemyPosition : MonoBehaviour {


	// Use this for initialization
	void Start () {
		

	}

	void OnDrawGizmos(){
		Gizmos.DrawWireSphere (transform.position, 0.5f);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
