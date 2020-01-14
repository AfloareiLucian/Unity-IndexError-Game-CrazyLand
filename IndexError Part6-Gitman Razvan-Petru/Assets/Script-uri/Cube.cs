﻿using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    public GameObject heart1, heart2, heart3, gameOver;
    public static int health;

    BoxCollider colider;     // Collider-ul caracterului
    Animator anim;           // animatorul caracterului
    Rigidbody rb;            //RigidBody-ul caracterului

    private GameObject obj; 
    Animator obj_anim;          
    Collider obj_collider;

    string message = "-1 LIFE";
    string message1 = "YOU WIN";
    string death = "YOU ARE DEAD";              
    bool displayMessage = false;
    bool displayMessage1 = false;
    bool displayMessage2 = false;

    private float speed, jumpforce = 9;         //viteza si puterea de salt a caracterului 
    public float init_speed = 0.1f;             //viteza de baza a caracterului
    private int hp = 3;                         //numarul de vieti a caracterului
    private bool control = true;                //deterimna daca utilizatorul poate controla caracterul: true-permite controlarea; false-nu permite controlarea
    float displayTime = 3;                      //??
    bool isGrounded;                            //true-caracterul este in contact cu solul; false- caracterul nu este in contact cu solul                   
    bool forward = true;                        //true- caracterul se misca (automat) inainte; false-caracterul nu se poate misca inainte


    bool isActivated = false;                   //true-caracterul va aluneca stanga sau dreapta aleator
    int contor_alunecare = 0, timp_alunecare=20;  
    float viteza_alunecare = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        //health = 3;
        //heart1.gameObject.SetActive(true);
        //heart2.gameObject.SetActive(true);
        //heart3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        obj_anim = GetComponent<Animator>();
        obj_collider = GetComponent<Collider>();
        speed = init_speed;
        colider = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        print("Good Luck!");
        rb.freezeRotation = true;
        // colider.transform.Translate(2f,0,0);
        viteza_alunecare = Random.Range(-0.3f, 0.3f);
    }


    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name.Contains("healt_up"))
        {
            Destroy(col.gameObject);
            hp++;
            //Cube.health += 1;
            print("LIFE REMAINING : " + hp);
        }

        if (col.gameObject.name.Contains("Capcana") || col.gameObject.name.Contains("Obstacol")
            || col.gameObject.name.Contains("trap") || col.gameObject.name.Contains("Tree_trap") )
        {
            Destroy(col.gameObject);
            hp--;
            Cube.health -= 1;
            if (hp > 0)
            {
                print("LIFE REMAINING : " + hp);
                displayMessage = true;
                displayTime = 3;
            }
        }

        if (col.gameObject.name.Contains("Multiple_spike_trap"))
        {
            hp = 0;
        }

        if (col.gameObject.name.Contains("Ice"))
        {
            isActivated = true;
        }

        if(col.gameObject.name.Contains("Snowman"))
        {
            hp--;
            //Cube.health += 1;
            if (hp > 0)
            {
                print("LIFE REMAINING : " + hp);
                displayMessage = true;
                displayTime = 3;
            }
        }

        if (col.gameObject.name.Contains("Swiper"))
        {
            forward = control = false;
            col.gameObject.GetComponent<Animator>().Play("Idle");
        }
        else
        {
            forward = control = true;
        }


        if (col.gameObject.name.Contains("banana_peel"))
        {
            isActivated = true;
            obj = col.gameObject;
            obj_collider = obj.GetComponent<Collider>();
            obj_anim = col.gameObject.GetComponent<Animator>();
            StartCoroutine(Play_and_Dissapear());

        }

        if (col.gameObject.name.Contains("oil"))
        {
            speed = init_speed / 3;
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
            SceneManager.LoadScene("Level2");
        }


        anim.Play("Run");

    }

    // Update is called once per frame
    void Update()
    {
        displayTime -= Time.deltaTime;
        if (displayTime <= 0.0)
        {
            displayMessage = false;
        }

        if (health > 3)
            health = 3;

       /*switch(health)
        {
            case 3:
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
            break;
            case 2:
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(false);
            break;
            case 1:
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
            break;
            case 0:
            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
            break;
        }*/

        if (hp == 0)
        {
            print("YOU LOSE");
            displayMessage2 = true;
            displayTime = 3;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && rb.velocity.y == 0)
        {
            rb.AddForce(new Vector3(0, jumpforce, 0), ForceMode.Impulse);
            anim.Play("Jump");
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.D) && control)
        {
            transform.Translate(speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.A) && control)
        {
            transform.Translate(-speed, 0f, 0f);
        }

        if (forward)
        {
            transform.Translate(0f, 0f, speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, -speed);
        }

        if (isActivated)
        {
            if (contor_alunecare <= timp_alunecare)
            {

                control = false;
                transform.Translate(viteza_alunecare, 0, 0);
                contor_alunecare++;
            }
            else
            {
                isActivated = false;
                contor_alunecare = 0;
                viteza_alunecare = Random.Range(-0.3f, 0.3f);
                control = true;
            }
        }

    }

    private void setObj(GameObject _obj)
    {
        obj = _obj;
        obj_anim = obj.GetComponent<Animator>();
        obj_collider = obj.GetComponent<Collider>();
    }

    //isGrounded: true- caracterul este pe pamant, false - caracterul sare;
    void OnCollisionStay()
    {
        isGrounded = true;

    }

    //Metoda se apeleaza la contactul cu coaja de banana
    IEnumerator Play_and_Dissapear()
    {
        obj_anim.Play("Colision");   //se activeaza animatia coajei de banana
        obj_collider.enabled = false; //se dezactiveaza coliziunea dintre coaja de banana si caracter       
        yield return new WaitForSeconds(3f); //se asteapta terminarea animatiei
        obj.SetActive(false); // coaja de banana este dezactivata
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