using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman : MonoBehaviour
{
    private bool reverse=false;
    public float speedX = 0f, speedY = 0f, speedZ = -0.025f;
    public int timp_atasare = 100;
    private int i = 0, k = 0;
    private bool isHooked = false, isDisabled=false;
    public int time = 0, contor_dezactivare = 0;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (i <= time )
        {
            transform.Translate(speedX, speedY, speedZ);
            i++;
        }
        else
        {
            transform.Rotate(0, 180, 0);
            speedY = -speedY;
            i = 0;
            reverse = !reverse;
        }

        if (isHooked == true)
        {
            if (k <= timp_atasare)
            {
                if (reverse == false)
                {
                    player.transform.position = transform.position + new Vector3(0.2f, 0, -1.5f);
                }
                else
                {
                    player.transform.position = transform.position + new Vector3(0.2f, 0, 1.5f);
                }
                k++;
            }
            else
            {
                k = 0;
                isHooked = false;
            }
        }

        if (isDisabled)
        {
            if (contor_dezactivare <= 100)
            {
                GetComponent<Collider>().enabled = false;
                contor_dezactivare++;
            }
            else
            {
                isDisabled = false;
                contor_dezactivare = 0;
                GetComponent<Collider>().enabled = true;
            }
        }

    }

   private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Cube"))
        {
            player = col.gameObject;
            isHooked = true;
        }
    }

}
