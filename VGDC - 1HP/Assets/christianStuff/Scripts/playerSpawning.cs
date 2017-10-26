using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSpawning : MonoBehaviour
{
    public bool isAlive;
    public GameObject deathCam;//This is the camera in the scene that the view will switch to when the player is dead
    public float deathTimer;
    float time_temp;
    public GameObject player;//This is the player itself, need this to destroy player when needed
    public GameObject playerPrefab;//This is a prefab of the player, used when we need to spawn in a new player
    float respawntime;
    public GameObject respawnText;
    public GameObject heartText;
    public GameObject heartIcon;
    public Texture2D heartIconPicture;
    public Texture2D BrokenHeartPicture;

    // Use this for initialization
    void Start()
    {
        heartIcon = GameObject.Find("heartIcon");
        respawnText = GameObject.Find("respawnText");
        heartText = GameObject.Find("heartText");
        respawntime = 3f;
        deathTimer = 100f;//When timer is 100,player should be getting spawned or already alive, when < 100 player is dead/respawning
        isAlive = true;//Self Explanitory Bool
        time_temp = 0f;
        player = GameObject.Find("Player");
    }

    public void destroyPlayer()
    {
        Destroy(player);
        deathTimer = 0f;
        isAlive = false;
        time_temp = 0f;
    }
    public void spawnPlayer()
    {
        deathCam.GetComponent<Camera>().depth = 0;
        deathTimer = respawntime;
        Instantiate(playerPrefab, GameObject.Find("spawnPoint1").transform.position, Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        if (deathTimer < respawntime)
        {
            deathCam.GetComponent<Camera>().depth = 2;
            print("try");
            time_temp += Time.deltaTime;
            deathTimer = Mathf.Lerp(0f, respawntime, time_temp / respawntime);
            int temp = (int)respawntime - (int)deathTimer;
            respawnText.GetComponent<Text>().text = "RESPAWNING IN..." + temp.ToString();
            heartText.GetComponent<Text>().text = "0";
            heartIcon.GetComponent<RawImage>().texture = BrokenHeartPicture;
        }
        if (isAlive == false && deathTimer == respawntime)
        {
            heartIcon.GetComponent<RawImage>().texture = heartIconPicture;
            respawnText.GetComponent<Text>().text = "";
            heartText.GetComponent<Text>().text = "1";
            isAlive = true;
            spawnPlayer();
        }

    }

}