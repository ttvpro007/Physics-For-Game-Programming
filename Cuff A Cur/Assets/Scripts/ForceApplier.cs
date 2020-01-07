using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplier : MonoBehaviour
{
    // static variables
    private static ForceApplier instance = null;
    public static ForceApplier Instance { get { return instance; } }

    // private variables
    private Rigidbody rb = null;
    private float mass = 0;
    private float forceMagnitude = 0;
    private float velocity = 0;
    private Vector3 moveDirection = -Vector3.forward; // set as moving backward when got punched

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Initiate();
    }

    private void Initiate()
    {
        rb = GetComponent<Rigidbody>();

        if (!rb)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            Debug.Log("There was no rigidbody component. Rigidbody component has been added.");
        }

        mass = rb.mass;

        if (mass <= 0)
        {
            mass = 1;
            Debug.Log("Mass value <= 0. Mass is set to 1.");
        }
    }

    private void FixedUpdate()
    {
        velocity = forceMagnitude / mass * Time.fixedDeltaTime;
        rb.velocity = moveDirection * velocity;
        //rb.MovePosition(moveDirection * velocity);
    }

    public void GetForceFromInputRegister(float forceMagnitude)
    {
        this.forceMagnitude = forceMagnitude;
    }

    private void Reset()
    {
        forceMagnitude = 0;
        velocity = 0;
        moveDirection = -Vector3.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Reset();
    }
}
