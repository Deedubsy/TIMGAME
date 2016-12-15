using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    private Rigidbody2D body2d;
    private float originalPos = 22400;
    private float rightPos = 24000;
    private float leftPos = 20000;
    private int dir = 1;
    public float speed = 1000f;
    public float projectileTimer = 5.0f;

    public Rigidbody2D projectile;
    public Rigidbody2D player;

    // Use this for initialization
    void Start () {
        body2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (body2d.position.x >= rightPos)
            dir = -1;

        if (body2d.position.x <= leftPos)
            dir = 1;

        var velX = speed * dir;

        body2d.velocity = new Vector2(velX, body2d.velocity.y);

        projectileTimer -= Time.deltaTime;

        if (projectileTimer < 0)
        {
            projectileTimer = 5.0f;

            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();

            var proj = (Rigidbody2D)Instantiate(projectile, transform.position, Quaternion.identity);

            proj.velocity = direction * 500;
        }
    }
}
