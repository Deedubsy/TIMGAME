using UnityEngine;
using System.Collections;

public class Walk : AbstractBehavoir
{
    public float speed = 80f;
    public float runMultiplier = 2f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);
        var shift = inputState.GetButtonValue(inputButtons[2]);

        if (right || left)
        {
            var tempSpeed = speed;

            if (shift && runMultiplier > 0) tempSpeed *= runMultiplier;

            var velX = tempSpeed * (float)inputState.direction;

            body2d.velocity = new Vector2(velX, body2d.velocity.y);
        }
        else
            body2d.velocity = new Vector2(0, body2d.velocity.y);

    }
}
