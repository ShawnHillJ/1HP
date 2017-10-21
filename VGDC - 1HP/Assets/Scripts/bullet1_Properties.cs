using UnityEngine;
using System.Collections;

public class bullet1_Properties : MonoBehaviour {

    string selfName;
    public GameObject primaryExplosionPrefab;
    public GameObject secondaryExplosionPrefab;
    public AudioSource sounds;
    public AudioClip explosionSound1;
    public AudioClip explosionSound2;

    void primaryExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(primaryExplosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
    void secondaryExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(secondaryExplosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }


    // Use this for initialization
    void Start () {
        sounds = GameObject.Find("explosionSound").GetComponent<AudioSource>();
        selfName = gameObject.name;
    }
	
	// Update is called once per frame
	void Update () {
       
	}
    private void OnCollisionEnter(Collision collision)
    {

        if (selfName.Contains("bullet1"))
        {
            sounds.clip = explosionSound1;
            sounds.Play();
            primaryExplosion();
            print("explosion!");
            Destroy(gameObject);
        }
        else if (selfName.Contains("bullet2"))
        {
            sounds.clip = explosionSound2;
            sounds.Play();
            secondaryExplosion();
            print("explosion!");
            Destroy(gameObject);
        }
    }
}

