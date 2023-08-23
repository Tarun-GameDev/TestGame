using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Sphere OtherSphere;
    [SerializeField] float _force;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            //rb.isKinematic = true;

            //OtherSphere.GetComponent<Rigidbody>().isKinematic = false;
            OtherSphere.GetComponent<Rigidbody>().AddForce(Vector3.up * Time.deltaTime * _force, ForceMode.Impulse);
        }

    }
}
