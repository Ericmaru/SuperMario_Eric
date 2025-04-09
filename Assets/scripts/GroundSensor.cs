using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;
    private enemy _enemyScript;
    private Rigidbody2D _rigidBody;
    public float jumpDamage = 5;
    private PlayerControler playerScript;

    void Awake()
    {
        _rigidBody = GetComponentInParent<Rigidbody2D>();
        playerScript = GetComponentInParent<PlayerControler>();
    }

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
            _rigidBody.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
            enemy _enemyScript = collider.gameObject.GetComponent<enemy>();
            _enemyScript.TakeDamage(jumpDamage);
        }
        else if(collider.gameObject.layer == 10)
        {
            playerScript.Death();
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
