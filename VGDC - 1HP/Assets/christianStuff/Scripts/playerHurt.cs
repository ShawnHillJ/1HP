using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHurt : MonoBehaviour {

    private void Awake()
    {
        GameObject.Find("Scripts").GetComponent<playerSpawning>().player = gameObject;//sets the player gameobject in playerSpawning to this object when it is created
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "instaDeath")
        {
            GameObject.Find("Scripts").GetComponent<playerSpawning>().destroyPlayer();//Calls the function in playerSpawning to say that the player has been killed 

            print("PLayer has died");
        }
    }
} 
