using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MoveClawButtonController : MonoBehaviour
{
    public Animator rightButtonAnimator;
    public Animator leftButtonAnimator;

    public enum Directions
    {
        Left,
        Right
    }

    public Directions direction;

    // Update is called once per frame
    void Update()
    {
        if (PlayerClawController.instance.state == PlayerClawController.States.DEFAULT || PlayerClawController.instance.state == PlayerClawController.States.DEFAULT_WITH_PRIZE)
        {
            rightButtonAnimator.SetBool("IsButtonPressed", false);
            leftButtonAnimator.SetBool("IsButtonPressed", false);
            Move();
        } else if (PlayerClawController.instance.state == PlayerClawController.States.GOING_DOWN)
        {
            rightButtonAnimator.SetBool("IsButtonPressed", true);
            leftButtonAnimator.SetBool("IsButtonPressed", true);
        }
    }

    void Move()
    {
        if (PlayerClawController.instance.moveRight)
        {
            leftButtonAnimator.SetBool("IsButtonPressed", false);
            rightButtonAnimator.SetBool("IsButtonPressed", true);
            return;
        } else if (PlayerClawController.instance.moveLeft)
        {
            leftButtonAnimator.SetBool("IsButtonPressed", true);
            rightButtonAnimator.SetBool("IsButtonPressed", false);
            return;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
            switch (direction)
            {
                case Directions.Left:
                    if (horizontalInput < 0)
                    {
                        leftButtonAnimator.SetBool("IsButtonPressed", true);
                        rightButtonAnimator.SetBool("IsButtonPressed", false);
                    }
                    break;
                case Directions.Right:
                    if (horizontalInput > 0)
                    {
                        leftButtonAnimator.SetBool("IsButtonPressed", false);
                        rightButtonAnimator.SetBool("IsButtonPressed", true);
                    }
                    break;
            }
        }
        else
        {
            leftButtonAnimator.SetBool("IsButtonPressed", false);
            rightButtonAnimator.SetBool("IsButtonPressed", false);
        }

    }
}
