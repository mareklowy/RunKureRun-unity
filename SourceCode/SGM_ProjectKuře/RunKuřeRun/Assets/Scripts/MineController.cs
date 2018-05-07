using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour {

	[SerializeField] private GameObject _explosion;
	
	private PlayerControls _pc;
	
	
	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("Player")) {
			Explode();
			Rigidbody _rb = other.gameObject.GetComponent<Rigidbody>();
			_pc = other.gameObject.GetComponent<PlayerControls>();
			_rb.velocity = new Vector3(0, 0, 0);
			StartCoroutine(SlowDown());
		}
	}

	private void Explode() {
		Destroy(Instantiate(_explosion, transform.position, Quaternion.identity), 3f);
		Vector3 newPos = transform.position + new Vector3(0, -10, 0);
		transform.position = newPos;
	}

	IEnumerator SlowDown() {
		float speed = _pc._speedIncrement;
		_pc._speedIncrement = 0;
		yield return new WaitForSeconds(1);
		_pc._speedIncrement = speed;
	}
}
