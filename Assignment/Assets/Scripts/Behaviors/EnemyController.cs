using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    private CircleCollider2D m_boxCollider2D;
    private bool isDead = false;
    private float timeSinceDeath = 0.0f;
    private float WalkDir = 1;

    // Use this for initialization
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.freezeRotation = true;

        m_boxCollider2D = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
            Walk();
        else
            m_Rigidbody2D.velocity = new Vector2(0, m_Rigidbody2D.velocity.y);

        if (isDead)
        {
            m_Rigidbody2D.rotation += 2.0f;
            timeSinceDeath += Time.fixedDeltaTime;
        }

        if(timeSinceDeath > 10.0f)
            Destroy(m_Rigidbody2D.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            WalkDir *= -1;
    }

    void Walk()
    {
        m_Rigidbody2D.velocity = new Vector2(100f * WalkDir, m_Rigidbody2D.velocity.y);
    }

    void DIE()
    {
        isDead = true;

        m_Rigidbody2D.freezeRotation = false;

        m_Rigidbody2D.AddForce(new Vector2(0, 1800.0f));

        m_boxCollider2D.enabled = false;
    }
}
