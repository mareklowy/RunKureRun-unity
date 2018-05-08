using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CollisionController : MonoBehaviour {
   
    private Rigidbody _rb;
    private PlayerControls _pc;
    private AudioSource _aus;
    private float _normalSpeed;
    
    [SerializeField] private float _speedSlowDown;

    // Use this for initialization
    void Start() {
        _rb = GetComponent<Rigidbody>();
        _pc = GetComponent<PlayerControls>();
        _normalSpeed = _pc._speedIncrement;
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
        _pc._speedIncrement = _speedSlowDown;
        print("Starting");
        yield return new WaitForSeconds(3);
        print("Ended");
        _pc._speedIncrement = _normalSpeed;
    }

    // Update is called once per frame
    void Update() { }
}