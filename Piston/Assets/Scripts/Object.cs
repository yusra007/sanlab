using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
   //public float time;
   //public Text timeT;
    Rigidbody rb;
    public bool taken = false;

    [HideInInspector]
    public bool hasReseted;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //time = 10;
        //timeT.text = " " + (int)time;
    }

    private void Update()
    {
        if (taken == true)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("pivot");
            rb.MovePosition(obj.transform.position);
            rb.MoveRotation(Quaternion.LookRotation(Camera.main.transform.forward));



            rb.useGravity = false;

        }
        else
        {
            rb.useGravity = true;
        }
        if (hasReseted == false)
        {
            resetForce();
            hasReseted = true;
        }



    }




   
    public void resetForce()
    {
        rb.isKinematic = false;
        rb.isKinematic = true;
    }
    public void Force()
    {
        rb.AddForce(Camera.main.transform.forward, ForceMode.Impulse);
    }
}
