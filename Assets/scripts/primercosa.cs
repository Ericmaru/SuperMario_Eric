using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primercosa : MonoBehaviour
{
   bool boleana = true;


   private int[] numeros = {75, 1, 3};
   public int[] numeros2;
   private int[ , ] numeros3 = {{7, 8, 98},{9, 22, 45}};
   List<int> listaDeNumeros = new List<int> {3, 5, 8, 9, 88, 12};
   
    // Start is called before the first frame update
    void Start()
    {
      foreach(int numero in listaDeNumeros)
      {
        Debug.Log(numero);
      }
      
      listaDeNumeros.Add(22);
      listaDeNumeros.Remove(5);
      listaDeNumeros.RemoveAt(0);
      //listaDeNumeros.RemoveAt(listaDeNumeros.Count - 1);
      listaDeNumeros.Sort();
      listaDeNumeros.Reverse();


      foreach(int numero in listaDeNumeros)
      {
        Debug.Log(numero);
      }
      
      listaDeNumeros.Clear();
      
       /*Debug.Log(numeros[0]);
       Debug.Log(numeros3[1,2]);
      
        //Calculos();

        /* foreach(int numero in numeros)
        {
            Debug.Log(numero);
        }
        for(int i = 0; i < numeros.Length; i++)
        {
            Debug.Log(i);
        }


        int i = 0;
        while(I < numeros.Length)
        {
            Debug.Log(numros[i]);
            i++;
        }

        int i = 75;
        do
        {
            Debug.Log("asfafs")
        }
        while (i < numeros.Length)*/


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
