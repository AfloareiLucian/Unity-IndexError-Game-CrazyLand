using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        print("Cube");
        rb.freezeRotation = true;
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Capcana")
        {
            Destroy(col.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0,8, 0), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.1f, 0f, 0f);
        }
       // if (Input.GetKey(KeyCode.W))
       // {
            transform.Translate(0f, 0f, 0.1f);
        //}
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, -0.1f);
        }
    }
}
