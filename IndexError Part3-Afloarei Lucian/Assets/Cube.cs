using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    BoxCollider colider;
    Animator anim;
    Rigidbody rb;
    string message = "-1 LIFE";
    string message1 = "YOU WIN";
    string death = "YOU ARE DEAD";
    bool displayMessage = false;
    bool displayMessage1 = false;
    bool displayMessage2 = false;
    private float speed, jumpforce=7;
    public float init_speed = 0.1f;
    private int hp = 3;
    float displayTime = 3;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        speed = init_speed;
        colider = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
        print("Good Luck!");
        rb.freezeRotation = true;
       // colider.transform.Translate(2f,0,0);
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "healt_up")
        {
            Destroy(col.gameObject);
            hp++;
            print("LIFE REMAINING : " + hp);
        }

        if (col.gameObject.name.Contains("Capcana") || col.gameObject.name.Contains("Obstacol") || col.gameObject.name.Contains("trap") || col.gameObject.name.Contains("Tree_trap"))
        {
            Destroy(col.gameObject);
            hp--;
            if (hp > 0)
            {
                print("LIFE REMAINING : "+hp);
                displayMessage = true;
                displayTime = 3;
            }
        }

        if (col.gameObject.name.Contains("oil"))
        {
            speed = speed / 3;
            jumpforce = 2;
        }
        else
        {
            speed = init_speed;
            jumpforce = 7;
        }

        if (col.gameObject.name == "Cube")
        {
            displayMessage1 = true;
            displayTime = 3;
        }


        anim.Play("Run");
    }

    void OnCollisionStay()
    {
        isGrounded = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        displayTime -= Time.deltaTime;
        if (displayTime <= 0.0)
        {
            displayMessage = false;
        }

        if (hp == 0)
        {
            print("YOU LOSE");
            displayMessage2 = true;
            displayTime = 3;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && rb.velocity.y == 0)
        {
            rb.AddForce(new Vector3(0,jumpforce, 0), ForceMode.Impulse);
            anim.Play("Jump");
            isGrounded = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed, 0f, 0f);
        }

        //if (Input.GetKey(KeyCode.W))
        //{
        transform.Translate(0f, 0f, speed);
        //}
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, -speed);
        }
    }

    private void OnGUI()
    {
        if (displayMessage)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 400f, 400f), message);
        }
        if (displayMessage1)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 400f, 400f), message1);
            print("YOU WIN");
            Destroy(this);
        }
        if (displayMessage2)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 400f, 400f), death);
            Destroy(this);
        }
    }
}
