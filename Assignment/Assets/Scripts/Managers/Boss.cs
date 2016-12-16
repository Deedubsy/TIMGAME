using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    private Rigidbody2D body2d;
    private float originalPos = 22400;
    private float rightPos = 24000;
    private float leftPos = 20100;
    private int dir = 1;
    public float speed = 1000f;
    public float projectileTimer = 5.0f;

    public Rigidbody2D projectile;
    public Rigidbody2D player;

    private CircleCollider2D m_boxCollider2D;

    private bool isDead = false;
    private float timeSinceDeath = 0.0f;

    // Use this for initialization
    void Start () {
        body2d = GetComponent<Rigidbody2D>();
        m_boxCollider2D = GetComponent<CircleCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {

        if (isDead)
        {
            body2d.rotation += 2.0f;
            timeSinceDeath += Time.fixedDeltaTime;
        }

        if (timeSinceDeath > 10.0f)
            Destroy(body2d.gameObject);

        if (body2d.position.x >= rightPos)
            dir = -1;

        if (body2d.position.x <= leftPos)
            dir = 1;

        var velX = speed * dir;

        body2d.velocity = new Vector2(velX, body2d.velocity.y);

        if(player.transform.position.x > 16000)
        {
            projectileTimer -= Time.deltaTime;

            if (projectileTimer < 0)
            {
                projectileTimer = 5.0f;

                Vector2 direction = player.transform.position - transform.position;
                direction.Normalize();

                var proj = (Rigidbody2D)Instantiate(projectile, transform.position, Quaternion.identity);

                proj.velocity = direction * 1000;
            }
        }
    }

    void DIE()
    {
        isDead = true;

        body2d.freezeRotation = false;

        body2d.AddForce(new Vector2(0, 1800.0f));

        m_boxCollider2D.enabled = false;
    }
}
