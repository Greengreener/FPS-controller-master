using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [Header("Physics")]
    //public float gravity = 20f;
    Rigidbody rb;
    [Header("Movement Variables")]
    float speed = 500;
    float jumpSpeed = 5f;
    public Vector3 moveDirection;

    public Animator animator;
    public int movementAnim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        float horizontal = 0;
        float vertical = 0;

        if (Input.GetKey(KeyCode.W))
        {
            vertical++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vertical--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontal++;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontal--;
        }
        moveDirection = new Vector3(horizontal, 0, vertical);
        rb.AddRelativeForce(moveDirection * speed * Time.deltaTime, ForceMode.Force);
        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x));
        animator.SetFloat("ForwardSpeed", Mathf.Abs(moveDirection.z));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }
}