using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public int direction = 1;
    public float speed = 5;
    private Animator _animator;
    private AudioSource _audioSource;
    private Rigidbody2D _rigidBody;
    public AudioClip AudioMuerte;
    BoxCollider2D _boxColider;
    public float maxHealth;
    private float currentHealth;
    private Slider _healthBar;

void Awake()
{
    _animator = GetComponent<Animator>();
    _audioSource = GetComponent<AudioSource>();
    _rigidBody = GetComponent<Rigidbody2D>();
    _boxColider = GetComponent<BoxCollider2D>();
    _healthBar = GetComponentInChildren<Slider>();
}
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        currentHealth = maxHealth;
        _healthBar.maxValue = maxHealth;
        _healthBar.value = maxHealth;

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
    Destroy(gameObject, 2);
}

public void TakeDamage(float damage)
{
    currentHealth-= damage;
    _healthBar.value = currentHealth;

    if(currentHealth <= 0)
    {
        Death();
       _audioSource.PlayOneShot(AudioMuerte);
    }
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
