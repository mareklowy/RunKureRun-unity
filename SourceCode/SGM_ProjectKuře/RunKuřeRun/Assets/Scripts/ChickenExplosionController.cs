using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenExplosionController : MonoBehaviour {

	[SerializeField] private GameObject _explosion;
	[SerializeField] private GameObject _burnedChicken;

	private PowerUPController _powerUP;

	private void Start() {
		_powerUP = GetComponent<PowerUPController>();
	}

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("Chicken")) {
			Vector3 chickenPos = other.gameObject.transform.position;
			Destroy(other.gameObject);
			Destroy(Instantiate(_explosion, chickenPos, Quaternion.identity), 3f);
			Instantiate(_burnedChicken, chickenPos, Quaternion.identity);
			_powerUP.GivePowerUP();
		}
	}
}
