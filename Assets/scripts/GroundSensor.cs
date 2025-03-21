using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;
    private enemy _enemyScript;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3)
        {
            isGrounded = true;
            Debug.Log(collider.gameObject.name);
            Debug.Log(collider.gameObject.transform.position);
        }
        else if(collider.gameObject.layer == 6)
        {
            enemy _enemyScript = collider.gameObject.GetComponent<enemy>();
            _enemyScript.Death();
        }


    }
    void OnTriggerStay2D(Collider2D collider)
    {
     if(collider.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
      if(collider.gameObject.layer == 3)
        {
        isGrounded = false;
        }
    }
}
