using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BombController : MonoBehaviour {

	[SerializeField] private GameObject _explosion;

	private void Start() {
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3(20,0,0);
	}

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("Obstacle")) {
			Destroy(Instantiate(_explosion, transform.position, Quaternion.identity), 3f);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
