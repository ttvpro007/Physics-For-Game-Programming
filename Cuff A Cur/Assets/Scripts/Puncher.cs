using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puncher : MonoBehaviour
{
    [SerializeField] GameObject punchingObject = null;

    public void Punch(float force)
    {
        Vector3 direction = punchingObject.transform.TransformDirection(-Vector3.forward);
        punchingObject.GetComponent<Rigidbody>().AddForce(direction * force);
    }
}
