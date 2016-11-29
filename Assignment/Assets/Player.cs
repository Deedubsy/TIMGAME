using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    private float m_MaxSpeed = 100f;                    // The fastest the player can travel in the x axis.
    [SerializeField]
    private float m_JumpForce = 400f;
    
    private Rigidbody2D m_Rigidbody2D;
    private bool isfacingRight = true;

    // Use this for initialization
    void Start () {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.freezeRotation = true;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
            coll.gameObject.SendMessage("DIE");
    }

    // Update is called once per frame
    void Update () {       

        //LEFT
        if (Input.GetKey(KeyCode.A))
        {
            if (isfacingRight)
            {
                Flip(false);
            }

            m_Rigidbody2D.velocity = new Vector2((-m_MaxSpeed * Time.deltaTime) * m_MaxSpeed, m_Rigidbody2D.velocity.y);
        }

        //LEFT
        if (Input.GetKey(KeyCode.D))
        {
            if(!isfacingRight)
            {
                Flip(true);
            }
            
            m_Rigidbody2D.velocity = new Vector2((m_MaxSpeed * Time.deltaTime) * m_MaxSpeed, m_Rigidbody2D.velocity.y);
        }

        //LEFT
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Rigidbody2D.AddForce(new Vector2((m_MaxSpeed * Time.deltaTime) * m_MaxSpeed, m_JumpForce));
        }
    }

    public void Flip(bool isRight)
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        m_Rigidbody2D.transform.localScale = theScale;
        isfacingRight = isRight;
    }
}
