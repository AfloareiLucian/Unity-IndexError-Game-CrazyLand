using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traptimer : MonoBehaviour
{

    Animator anim;
    public float waitTime, waitTime2;

    // Start is called before the first frame update
    void Start()
    {
        anim =GetComponent<Animator>();       
        InvokeRepeating("PlayAnim", 3f, waitTime);
        InvokeRepeating("PlayAnim2", 4f, waitTime2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayAnim()
    {
        anim.Play("Thrust");
    }

    void PlayAnim2()
    {
        anim.Play("Retract");
    }
}
