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
    public Rigidbody2D rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        groundSensor = GetComponentInChildren<GroundSensor>();
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
        inputHorizontal = Input.GetAxisRaw("Horizontal"); //el movimiento se hace exacto con Raw
      //transform.position = new Vector3(transform.position.x + direction * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z);
      //transform.Translate(new Vector3(direction * playerSpeed * Time.deltaTime, 0, 0));
      //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + inputHorizontal, transform.position.y), playerSpeed * Time.deltaTime);

      if(Input.GetButtonDown("Jump") && groundSensor.isGrounded == true) //boton salto + boleana detector de suelo
      {
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //hace que salte
      }

    }
    void FixedUpdate() //formas de avanzar de derecha a izquierda
    {
        rigidBody.velocity = new Vector2(inputHorizontal * playerSpeed, rigidBody.velocity.y);
        //rigidBody.AddForce(new Vector2(inputHorizontal, 0));
        //rigidBody.MovePosition(new Vector2(100, 0));
    }
}