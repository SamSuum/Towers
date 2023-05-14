using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    //[HideInInspector]public bool grap=false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destructible"))
        {
            Destroy(collision.gameObject);
            Debug.Log("collision");
        }
        /*if (collision.gameObject.CompareTag("platform"))
        {
            grap = true;
        }
        else grap = false;*/

    }
}
