using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    //player

    [Header("Playerのパラメータ")]
    [Tooltip("playerの移動スピード")]
    public float _speed = 1.0f;
    public float groundDragPower = 10.0f;
    public float _player_CenterHight;
    public LayerMask isGround;
    bool grounded;

    float _horizontal;
    float _vertical;

    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down,
           _player_CenterHight * 0.5f + 0.2f, isGround);

        //もし地面に接地していたい引力を考えたい（摩擦を考えるため）

        if (grounded)
        {
            _rb.drag = groundDragPower;
            _speed -= _speed % 1 * Time.deltaTime;
        }
        else
        {
            _rb.drag = 0;
            _speed = 0;
        }
        Move();
    }

    void Move()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        var verocity = new Vector3(_horizontal, 0, _vertical) * _speed;

        if (verocity.magnitude >= 0)
        {
            var newSpeed = verocity.normalized * _speed;

            _rb.velocity += newSpeed;
        }
    }
}