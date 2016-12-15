using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    private InputState inputState;
    private Walk walkBehavior;
    private Animator animator;
    private CollisionState collisionState;
    private CircleCollider2D circleCollider;

    private void Awake()
    {
        inputState = GetComponent<InputState>();
        walkBehavior = GetComponent<Walk>();
        collisionState = GetComponent<CollisionState>();
        circleCollider = GetComponent<CircleCollider2D>();
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
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = circleCollider.bounds.center;

            Vector3 dir = contactPoint - center;
            dir = circleCollider.transform.InverseTransformDirection(dir);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            Debug.Log(angle);

            if (angle < -60 && angle > -110) collision.gameObject.SendMessage("DIE");
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
