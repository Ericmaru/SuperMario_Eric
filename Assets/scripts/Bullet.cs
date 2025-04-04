using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public float bulletforce = 10;
    public float bulletDamage = 2;
    // Start is called before the first frame update
   
   void Awake()
   {
    _rigidBody = GetComponent<Rigidbody2D>();
   }
   
    void Start()
    {
       _rigidBody.AddForce(transform.right * bulletforce, ForceMode2D.Impulse); 
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 6)
        {
            enemy enemyScript = collider.gameObject.GetComponent<enemy>();
            enemyScript.TakeDamage(bulletDamage);
            BulletDeath();
        }

        if(collider.gameObject.layer == 3)
        {
            BulletDeath();
        }
    }

    void BulletDeath()
    {
        Destroy(gameObject);
    }
}
