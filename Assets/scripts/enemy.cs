using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int direction = 1;
    public float speed = 5;
    private Animator _animator;
    private AudioSource _audioSource;
    private Rigidbody2D _rigidBody;
    public AudioClip _audioClip;
    BoxCollider2D _boxColider;

void Awake()
{
    _animator = GetComponent<Animator>();
    _audioSource = GetComponent<AudioSource>();
    _rigidBody = GetComponent<Rigidbody2D>();
    _boxColider = GetComponent<BoxCollider2D>();
}
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

void FixedUpdate()
{
    _rigidBody.velocity = new Vector2(direction * speed, _rigidBody.velocity.y );
}

public void Death()
{
   _rigidBody.gravityScale = 0;
   _boxColider.enabled = false;
    _animator.SetTrigger("isdead");
    Destroy(gameObject, 0.3f);
}
void OnCollisionEnter2D(Collision2D collision)
{

    if(collision.gameObject.CompareTag("Tuberia") || collision.gameObject.layer == 6 ||  collision.gameObject.layer == 8)
    {
        direction *= -1;
    }

   


    if(collision.gameObject.CompareTag("Player"))
    {
        //Destroy(collision.gameObject);
        PlayerControler playerScript = collision.gameObject.GetComponent<PlayerControler>();
        playerScript.Death();
    }
}

    private void OnBecameVisible()
    {
        speed = 5;
    }

    private void OnBecameInvisible()
    {
        speed = 0;
    }
}
