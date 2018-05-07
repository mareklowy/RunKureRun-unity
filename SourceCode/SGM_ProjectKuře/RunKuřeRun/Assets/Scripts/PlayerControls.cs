using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControls : MonoBehaviour {
    
    private float _horizontal;
    private float _vertical;
    private Rigidbody _rb;
    private Animation _anim;
    public int _playerNO;
    
    [SerializeField] private float _maxSpeed;
    [SerializeField] public float _speedIncrement;

    // Use this for initialization
    void Start() {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update() {
        _horizontal = Input.GetAxis("Horizontal_" + _playerNO);
        _vertical = Input.GetAxis("Vertical_" + _playerNO);
    }

    private void FixedUpdate() {
        Vector3 currentVelocity = _rb.velocity;
        float speed = currentVelocity.magnitude;
         
        
        _rb.velocity = new Vector3(currentVelocity.x, currentVelocity.y, currentVelocity.z + _speedIncrement * _horizontal);

        if (speed < _maxSpeed) {
            _rb.velocity = new Vector3(currentVelocity.x + _speedIncrement * _vertical, currentVelocity.y, _rb.velocity.z);
        }

        Vector3 zero = new Vector3(0,0,0);
        if (_rb.velocity == zero) {               
            _anim.enabled = false;
            

        }
        else {
            _anim.enabled = true;
        }
    }
}