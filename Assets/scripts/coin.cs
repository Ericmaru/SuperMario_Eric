using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;
    public AudioClip CoinSFX;
    private SpriteRenderer _renderer;
    // Start is called before the first frame update
    
    void Awake()
    {
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

    }

    void OnCollisionEnter2D(Collision2D collision)
{

    if(collision.gameObject.CompareTag("Player"))
    {
        //Destroy(collision.gameObject);
        PlayerControler playerScript = collision.gameObject.GetComponent<PlayerControler>();
        Death();
    }
}
    public void Death()
{
   _boxCollider.enabled = false;
    _renderer.enabled = false;
     Destroy(gameObject, 0.5f);
    _audioSource.PlayOneShot(CoinSFX);

}
}
