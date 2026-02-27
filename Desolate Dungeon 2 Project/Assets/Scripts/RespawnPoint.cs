using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Respawnpoint : MonoBehaviour
{

    public GameObject player;
    public Transform respawnPoint;


    

    // Update is called once per frame
    private void OnCollissionEnter2D(Collision other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            
            player.transform.position = other.transform.position;

    }   }
}
