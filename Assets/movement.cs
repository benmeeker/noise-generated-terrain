using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public Rigidbody move;
    public float zforce = 20f;
    public float xforce = 20f;
    public float yforce = 25f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey("w"))
        {
            move.AddForce(0, 0, zforce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            move.AddForce(-xforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))
        {
            move.AddForce(xforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            move.AddForce(0, 0, -zforce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("space"))
        {
            move.AddForce(0, yforce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }
    }
}
