using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{


    [Header("Playerのパラメータ")]
    [Tooltip("playerの移動スピード")]
    public float _speed = 1.0f; 

    Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;

    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal") * _speed;
        var vertical = Input.GetAxisRaw("Vertical") * _speed;

        var velocity = new Vector3(horizontal , 
            0 , vertical).normalized;

        if(velocity.magnitude < _speed)
        {
            _rb.velocity = velocity * _speed * 1.5f;
        }
       
        
    } 
}
