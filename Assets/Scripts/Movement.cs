using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _Speed;
    [SerializeField] private float _JumpForce;
    [SerializeField] private float _JumpGrounDistance = 0.5f;
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private Transform _Camera;
    [SerializeField] private float _SensevityX;
    [SerializeField] private float _SensevityY;
    private float _mouseRotationX;
    private float _mouseRotationY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _mouseRotationX = transform.eulerAngles.x;
        _mouseRotationY = transform.eulerAngles.y;
    }

    private void Update()
    {
        Look();
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f) { return; }

        Vector3 right = Input.GetAxis("Horizontal") * _Speed * transform.right;
        Vector3 forward = Input.GetAxis("Vertical") * _Speed * transform.forward;
        Vector3 nextPosition = transform.position;

        RaycastHit hit;
        bool hasHit = Physics.Linecast(transform.position, (nextPosition + forward) * 1.2f, out hit);
        if (!hasHit) { nextPosition += forward; }
        hasHit = Physics.Linecast(transform.position, (nextPosition + right) * 1.2f, out hit);
        if (!hasHit) { nextPosition += right; }

        _rb.MovePosition(nextPosition);
    }

    private void Look()
    {
        _mouseRotationX += Input.GetAxis("Mouse Y") * _SensevityX;
        _mouseRotationY += Input.GetAxis("Mouse X") * _SensevityY;
        _mouseRotationX = Mathf.Clamp(_mouseRotationX, -90f, 90f);
        transform.rotation = Quaternion.Euler(0, _mouseRotationY, 0);
        _Camera.rotation = Quaternion.Euler(-_mouseRotationX, _mouseRotationY, 0);
    }

    private void Jump()
    {
        Vector3 GroundCheck = transform.position - transform.up * (transform.localScale.y / 2 + _JumpGrounDistance);
        RaycastHit hit;
        bool hasHit = Physics.Linecast(transform.position, GroundCheck, out hit);
        if (!hasHit) { return; }
        if (!Input.GetKeyDown(KeyCode.Space)) { return; }

        _rb.AddForce(Vector3.up * _JumpForce);
    }
}
