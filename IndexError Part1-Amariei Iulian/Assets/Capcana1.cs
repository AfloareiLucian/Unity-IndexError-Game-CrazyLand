using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capcana1 : MonoBehaviour
{
    private Vector3 v = new Vector3(0,3f,0);
    public GameObject capcana;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
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
