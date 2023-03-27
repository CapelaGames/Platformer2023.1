using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 4f;
    public float _jumpForce = 400f;
    
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    public float _xAxis;
    public bool _jump = false;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }
    //Move the object in FixedUpdate
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_xAxis * _speed * Time.deltaTime, 
                                            _rigidbody.velocity.y);

        if (_jump && GroundedCheck())
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _jump = false;
        }
    }
    
    private bool GroundedCheck()
    {
        Vector2 bottom = new Vector2(transform.position.x, transform.position.y - _collider.bounds.extents.y);
        
        float width = _collider.bounds.size.x;

        Collider2D[] hits = Physics2D.OverlapBoxAll(bottom,
                                new Vector2(width, 0.4f),0f);
        int index = 0;
        while (index < hits.Length)
        {
            if (hits[index].gameObject != gameObject)
            {
                return true;
            }
            index++;
        }

        return false;
    }
    
    //Get Controls in Update
    private void Update()
    {
        _xAxis = Input.GetAxis("Horizontal");
        if (_jump == false)
        {
            _jump = Input.GetButtonDown("Jump");
        }
    }
}
