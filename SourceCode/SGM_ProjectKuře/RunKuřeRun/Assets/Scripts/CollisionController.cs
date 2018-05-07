using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CollisionController : MonoBehaviour {
    private Rigidbody _rb;
    private PlayerControls _pc;
    private AudioSource _aus;

    [SerializeField] private float _speedSlowDown;

    // Use this for initialization
    void Start() {
        _rb = GetComponent<Rigidbody>();
        _pc = GetComponent<PlayerControls>();
        _aus = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Obstacle")) {
            print("Collision: " + other.gameObject.ToString());
            _aus.PlayOneShot(_aus.clip);
            _rb.velocity = new Vector3(0, 0, 0);
            StartCoroutine(SlowDown());
            Destroy(other.gameObject);
        }
    }

    IEnumerator SlowDown() {
        yield return null;
        float speed = _pc._speedIncrement;
        _pc._speedIncrement = _speedSlowDown;
        yield return new WaitForSeconds(3);
        _pc._speedIncrement = speed;
    }

    // Update is called once per frame
    void Update() { }
}