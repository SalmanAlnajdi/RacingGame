using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour
{

    private Rigidbody rb;
    public float speed = 8f;
    public float turnSpeed = 4f;
    public float Gforce = 9f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCar();
        TurnCar();
        FallCar();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("TheEnd");
        }
    }

    void MoveCar()
    {
        if (Input.GetKey("w"))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x,0,Vector3.forward.z) * speed * 10);
        }
        else if (Input.GetKey("s"))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * -speed * 10);
        }

        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        localVelocity.x = 0;
        rb.velocity = transform.TransformDirection(localVelocity);
    }

    void TurnCar()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeTorque(Vector3.up * turnSpeed * 10);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeTorque(-Vector3.up * turnSpeed * 10);
        }

    }
    void FallCar()
    {
        rb.AddForce(Vector3.down * Gforce);
    }
}
