using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawn : MonoBehaviour
{
   [Header("Spawn Enemigos")]
   [Tooltip("Prefabs de enemigos")]
   [SerializeField] private GameObject[] _enemiesPreFab;
   [Tooltip("Numero de enemigoss que van a spawnear")]
   [SerializeField] private int _enemiesToSpawn;
   [SerializeField] private Transform _spawnPoint;
   private BoxCollider2D _collider;
   private int _enemyIndex;
   
    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }
    
    
    
    
    void Update()
    {
        if(_enemiesToSpawn == 0)
        {
            CancelInvoke();
        }
    }

    IEnumerator SpawnEnemy()
    {
       for (int i = 0; i < _enemiesToSpawn; i++)
       {
         foreach(Transform spawn in _spawnPoint)
             {
             _enemyIndex = Random.Range(0, _enemiesPreFab.Length);
                Instantiate(_enemiesPreFab[_enemyIndex], spawn.position, _spawnPoint.rotation);
                yield return new WaitForSeconds(1);
            }

         yield return new WaitForSeconds(1);
       }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            _collider.enabled = false;
            //InvokeRepeating("SpawnEnemy", 0, 2);
            StartCoroutine(SpawnEnemy());
        }
    }
}
