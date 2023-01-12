using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    public float Distance = 5;
    public bool isTaked = false;

    public Transform pivot;
    [SerializeField] private Image crosshair = null;
    GameObject Item;
    private void Update()
    {

        if (isTaked == true)
        {

            var objComp = Item.GetComponent<Object>();
            if (objComp == false)
            {
                isTaked = false;
            }
            if (Input.GetMouseButtonDown(0))
            {

                objComp.Force();

                isTaked = false;

                objComp.taken = false;
            }
            crosshair.color = Color.white;
        }
        if (isTaked == false)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out hit, Distance) && hit.collider.gameObject.CompareTag("takeAble"))
            {
                crosshair.color = Color.red;
                if (Input.GetMouseButton(0))
                {
                    Item = hit.collider.gameObject;


                    Item.GetComponent<Object>().hasReseted = false;
                    Item.GetComponent<Object>().taken = true;
                    isTaked = true;
                }

            }
            else
            {
                crosshair.color = Color.white;
            }
        }

    }
}
