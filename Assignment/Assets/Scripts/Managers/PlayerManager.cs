using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    private InputState inputState;
    private Walk walkBehavior;
    private Animator animator;
    private CollisionState collisionState;
    private Jump jump;
    private CircleCollider2D circleCollider;
    private float jumpinterval = 0.5f;
    private bool enemyHit = false;

    private void Awake()
    {
        inputState = GetComponent<InputState>();
        walkBehavior = GetComponent<Walk>();
        collisionState = GetComponent<CollisionState>();
        circleCollider = GetComponent<CircleCollider2D>();
        jump = GetComponent<Jump>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 16000 && Camera.main.orthographicSize < 2000)
            Camera.main.orthographicSize += 25;
        else if (transform.position.x <= 16000 && Camera.main.orthographicSize > 900)
            Camera.main.orthographicSize -= 25;

        if (enemyHit)
        {
            if (jumpinterval > 0)
            {
                if (inputState.GetButtonValue(Buttons.Space))
                    jump.OnJump();
            }
            else
            {
                enemyHit = false;
                jumpinterval = 0.5f;
            }

            jumpinterval -= Time.deltaTime;
        }
    }

    void ChangeAnimation(int value)
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Enemy")
        //    collision.gameObject.SendMessage("DIE");

        //collisionState.CheckEnemyCollision(collision);
        //if (collision.gameObject.tag == "Enemy")
        //{
        Collider2D collider = collision.collider;

        if (collision.gameObject.tag == "Enemy")
        {
            enemyHit = true;

            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = circleCollider.bounds.center;

            Vector3 dir = contactPoint - center;
            dir = circleCollider.transform.InverseTransformDirection(dir);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            Debug.Log(angle);

            if (angle < -50 && angle > -130) collision.gameObject.SendMessage("DIE");
            else SceneManager.LoadScene(Application.loadedLevel);
            //else Application.LoadLevel(Application.loadedLevel);

            bool right = contactPoint.x > center.x;
            bool left = contactPoint.x < center.x;
            bool top = contactPoint.y > center.y;
            bool bottom = contactPoint.y < center.y;

            Debug.DrawLine(center, contactPoint);
        }


        //circleCollider
        //}
    }
}
