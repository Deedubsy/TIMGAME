using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.forward);
    }

    void OnCollisionEnter(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(Application.loadedLevel);
        }

        if (collision.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
}
