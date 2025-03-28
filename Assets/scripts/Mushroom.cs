using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public int direction = 1;
    public float speed = 2;
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;
    public AudioClip GlowUpSFX;
    private SpriteRenderer _renderer;
    // Start is called before the first frame update
    
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
{
    _rigidBody.velocity = new Vector2(direction * speed, _rigidBody.velocity.y );
}

    void OnCollisionEnter2D(Collision2D collision)
{

    if(collision.gameObject.CompareTag("Tuberia") || collision.gameObject.layer == 6)
    {
        direction *= -1;
    }

    if(collision.gameObject.CompareTag("Player"))
    {
        //Destroy(collision.gameObject);
        PlayerControler playerScript = collision.gameObject.GetComponent<PlayerControler>();
        playerScript.CanShoot = true;
        Death();
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
    public void Death()
{
   _rigidBody.gravityScale = 0;
   _boxCollider.enabled = false;
    _renderer.enabled = false;
     Destroy(gameObject, 0.9f);
    _audioSource.PlayOneShot(GlowUpSFX);

}

}
