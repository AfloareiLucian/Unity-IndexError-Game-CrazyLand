using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_anim : MonoBehaviour
{
    public GameObject capcana;
    public string denumire_anim;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
        anim = capcana.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.Play(denumire_anim);

    }

}
