using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    private BoxCollider2D m_boxCollider2D;
    private bool isDead = false;
    private float timeSinceDeath = 0.0f;

    // Use this for initialization
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.freezeRotation = true;

        m_boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
            m_Rigidbody2D.velocity = new Vector2((10 * Time.deltaTime) * 10, m_Rigidbody2D.velocity.y);
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

    void DIE()
    {
        isDead = true;

        m_Rigidbody2D.freezeRotation = false;

        m_Rigidbody2D.AddForce(new Vector2(0, 200.0f));

        m_boxCollider2D.enabled = false;
    }
}
