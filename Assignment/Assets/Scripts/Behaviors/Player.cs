using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    public float speed = 5f;                    // The fastest the player can travel in the x axis.
    [SerializeField]
    public float jumpForce = 500f;

    public Buttons[] input;

    private Rigidbody2D m_Rigidbody2D;
    private InputState inputState;

    private bool isfacingRight = true;

    // Use this for initialization
    void Start () {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.freezeRotation = true;

        inputState = GetComponent<InputState>();
    }

    // Update is called once per frame
    void Update () {

        var right = inputState.GetButtonValue(input[0]);
        var left = inputState.GetButtonValue(input[1]);

        var velX = speed;

        if(right || left)
        {
            velX *= left ? -1 : 1;
        }
        else
        {
            velX = 0;
        }

        m_Rigidbody2D.velocity = new Vector2(velX, m_Rigidbody2D.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            collision.gameObject.SendMessage("DIE");
    }

    public void Flip(bool isRight)
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        m_Rigidbody2D.transform.localScale = theScale;
        isfacingRight = isRight;
    }
}
