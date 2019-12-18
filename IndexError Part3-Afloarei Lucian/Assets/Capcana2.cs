using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capcana2 : MonoBehaviour
{
    public float dir_x, dir_y, dir_z;
    private Vector3 v;
    public GameObject capcana;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
        v = new Vector3(dir_x, dir_y, dir_z);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        capcana.transform.position += v;

    }
}