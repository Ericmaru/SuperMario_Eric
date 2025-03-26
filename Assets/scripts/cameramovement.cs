using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public Transform playerTransform;

    public Vector3 offset;

    public Vector2 maxPosition;
    public Vector2 minPosition;
    
    public float interpolationRatio = 0.5f;
    
    // Start is called before the first frame update
    void Awake()
    {
        //formas de encontrar al jugador

      //playerTransform = GameObject.Find("Mario_0").transform; //busca el objeto por nombre

      playerTransform = GameObject.FindWithTag("Player").transform;  //busca el objeto por tag
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(playerTransform == null)
      {
        return;
      }
    { 
     Vector3 desirePosition = playerTransform.position + offset;  //mover la camara
     float clampX = Mathf.Clamp(desirePosition.x, minPosition.x, maxPosition.x);
     float clampY = Mathf.Clamp(desirePosition.y, minPosition.y, maxPosition.y);
     
     Vector3 clampedPosition = new Vector3(clampX, clampY, desirePosition.z);
     
     Vector3 lerpePosition = Vector3.Lerp(transform.position, clampedPosition, interpolationRatio);
     
      transform.position = lerpePosition;
    }

    }
}
