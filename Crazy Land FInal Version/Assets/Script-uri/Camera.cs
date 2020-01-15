using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class Camera : MonoBehaviour
{
    public GameObject player;
    public float sensitivity;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        /*float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        transform.RotateAround(player.transform.position, -Vector3.up, rotateHorizontal * sensitivity); 
        transform.RotateAround(Vector3.zero, transform.right, rotateVertical * sensitivity); */
    }
}
