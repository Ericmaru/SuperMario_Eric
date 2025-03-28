using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float playerSpeed = 4.5f;
    public float jumpForce = 10;
    public int direction = 1;
    float inputHorizontal;
    private GroundSensor groundSensor;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public bool CanShoot = false;
    public float PowerUpDuration = 10f;
    public float PowerUpTimer;

SpriteRenderer _spriteRender;

    public Rigidbody2D rigidBody;

private Animator _animator;
private AudioSource _audioSource;
private BoxCollider2D _boxCollider;
private GameManager _gameManager;
private SoundManager _soundManager;

public AudioClip jumpSFX;
public AudioClip deathSFX;
public AudioClip shootSFX;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        groundSensor = GetComponentInChildren<GroundSensor>();
        _spriteRender = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //esto teletransporta al personaje
        //transform.position = new Vector3(13, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!_gameManager.isPlaying)
        {
            return;
        }
        
        inputHorizontal = Input.GetAxisRaw("Horizontal"); //el movimiento se hace exacto con Raw
      //transform.position = new Vector3(transform.position.x + direction * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
      //transform.Translate(new Vector3(direction * playerSpeed * Time.deltaTime, 0, 0));
      //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + inputHorizontal, transform.position.y), playerSpeed * Time.deltaTime);

      if(Input.GetButtonDown("Jump") && groundSensor.isGrounded == true) //boton salto + boleana detector de suelo
      {
       Jump ();
      }

    Movement();
   
   _animator.SetBool("IsJumping", !groundSensor.isGrounded);

   /* if(_groundSensor.isGrounded)
    {
        _animator.SetBool("IsJumping", true);
    }*/

    if(Input.GetButtonDown("Fire1") && CanShoot) 
    {
        Shoot();
    }
    if(CanShoot)
    {
        PowerUp();
    }
    }
    void FixedUpdate() //formas de avanzar de derecha a izquierda
    {
        rigidBody.velocity = new Vector2(inputHorizontal * playerSpeed, rigidBody.velocity.y);
        //rigidBody.AddForce(new Vector2(inputHorizontal, 0));
        //rigidBody.MovePosition(new Vector2(100, 0));
    }

    void Movement ()
{
    if(inputHorizontal > 0)
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _animator.SetBool("IsRunning", true);
    }
    else if(inputHorizontal < 0)
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        _animator.SetBool("IsRunning", true);
    }
    else if(inputHorizontal == 0)
    {
        _animator.SetBool("IsRunning", false);
    }
}

void Jump ()
{
    rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);  //hace que salte
    _audioSource.PlayOneShot(jumpSFX);
}

public void Death()
{
    _animator.SetTrigger("Dead");
    _audioSource.PlayOneShot(deathSFX);
    _boxCollider.enabled = false;

    Destroy (groundSensor.gameObject);
    rigidBody.velocity = Vector2.zero;
    _gameManager.isPlaying = false;
    StartCoroutine(_soundManager.DeathBGM());
    rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
}


void Shoot()
{
    Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    _audioSource.PlayOneShot(shootSFX);
}


void PowerUp()
{
    PowerUpTimer += Time.deltaTime;
    if(PowerUpTimer >= PowerUpDuration)
    {
        CanShoot = false;
        PowerUpTimer = 0;
    }
}


}