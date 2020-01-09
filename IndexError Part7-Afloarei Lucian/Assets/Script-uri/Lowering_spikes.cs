using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lowering_spikes : MonoBehaviour
{
    public GameObject capcana;
    private bool isActivated = false;
    public float speedX = 0f, speedY = 0f, speedZ = -0.025f;
    private int i=0;
    public int time=0;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated && i<=time)
        {
            capcana.transform.Translate(speedX, speedY, speedZ);           
            i++;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        isActivated = true;
    }

}
