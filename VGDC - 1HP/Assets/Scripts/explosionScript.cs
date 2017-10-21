using UnityEngine;
using System.Collections;

public class explosionScript : MonoBehaviour {

    public float explosionSize = 0.0f;
    public float explosionMaxSize = 1.36409f;
    // Use this for initialization

    private void Awake()
    {

        Vector3 size = gameObject.transform.localScale;
        //gameObject.transform.localScale = new Vector3(size.x + explosionSize, size.y + explosionSize, size.z + explosionSize);
        gameObject.transform.localScale = gameObject.transform.localScale * explosionSize;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            Vector3 epicenter = gameObject.transform.parent.transform.position;
            Vector3 player = other.transform.position;
            Vector3 direction = epicenter - player;
            other.GetComponent<Rigidbody>().AddForce(transform.up * 3f, ForceMode.Impulse);
            other.GetComponent<Rigidbody>().AddForce(direction * -50f, ForceMode.Impulse);
           
        }

        //print(other.transform.name);
    }


    // Update is called once per frame
    void FixedUpdate () {
        Vector3 size = gameObject.transform.localScale;
        if (gameObject.transform.localScale.x < explosionMaxSize)
        {
            gameObject.transform.localScale = new Vector3(size.x + explosionSize, size.y + explosionSize, size.z + explosionSize);
        }
        else
        {
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
}
