using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerShoot : MonoBehaviour {

    GameObject guntip = null;
    public bool playerIsAlive;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public Transform bulletSpawnPoint;
    public float primaryBulletSpeed;
    public float secondaryBulletSpeed;
    public float primaryTimer;
    public float secondaryTimer;
    public float primaryReloadTime;
    public float secondaryRelaodTIme;

    public AudioSource sounds;
    public AudioClip sound1;
    public AudioClip sound2;

    GameObject slider;
    float primarySliderTime;
    GameObject primaryLoader;
    float secondarySliderTime;
    GameObject secondaryLoader;
    bool secondaryIsDown;
	// Use this for initialization
	void Start () {
        playerIsAlive = true;
        sounds = gameObject.GetComponent<AudioSource>();
        slider = GameObject.Find("ammoSlider");
        primaryLoader = GameObject.Find("primary");
        secondaryLoader = GameObject.Find("secondary");
        primaryTimer = 0.0f;
        secondaryTimer = 0.0f;
        secondaryIsDown = false;
      //  guntip = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
      //   print(guntip.name);
    }
	
    void reload(GameObject thing)
    {
        print("reloading");
        if(thing.name == "primary")
        {
            primaryLoader.transform.localScale = new Vector3(primaryLoader.transform.localScale.x, primaryLoader.transform.localScale.y, 0);
            primaryTimer = 0.0f;
            primarySliderTime = 0.0f;
        }
        if (thing.name == "secondary")
        {
            secondaryLoader.transform.localScale = new Vector3(secondaryLoader.transform.localScale.x, secondaryLoader.transform.localScale.y, 0);
            secondaryTimer = 0.0f;
            secondarySliderTime = 0.0f;
        }


        //slider.GetComponent<Slider>().value = 0.01f;

    }
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(1) && playerIsAlive == true)
        {
            secondaryIsDown = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            secondaryIsDown = false;
        }


        if (Input.GetMouseButtonDown(0) && primaryTimer == 1 && playerIsAlive == true) 
        {
            sounds.clip = sound1;
            sounds.Play();
            GameObject bullet1 = (GameObject)Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward * primaryBulletSpeed;
            reload(primaryLoader);
        }

        if (secondaryIsDown == true && secondaryTimer == 1 && playerIsAlive == true)
        {
            sounds.clip = sound2;
            sounds.Play();
            GameObject bullet1 = (GameObject)Instantiate(bulletPrefab2, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward * secondaryBulletSpeed;
            reload(secondaryLoader);
        }
        if (primaryTimer < 1)
        {
            primarySliderTime += Time.deltaTime;
            primaryTimer =  Mathf.Lerp(0.01f, 1.0f,  primarySliderTime/primaryReloadTime);
            primaryLoader.transform.localScale = new Vector3(primaryLoader.transform.localScale.x, primaryLoader.transform.localScale.y, Mathf.Lerp(0.01f, 1.0f, primarySliderTime / primaryReloadTime));
        }
        if (secondaryTimer < 1)
        {
            secondarySliderTime += Time.deltaTime;
            secondaryTimer = Mathf.Lerp(0.01f, 1.0f, secondarySliderTime / secondaryRelaodTIme);
            secondaryLoader.transform.localScale = new Vector3(secondaryLoader.transform.localScale.x, secondaryLoader.transform.localScale.y, Mathf.Lerp(0.01f, 1.0f, secondarySliderTime / secondaryRelaodTIme));
        }




    }
}
