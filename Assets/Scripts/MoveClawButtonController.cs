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
    void FixedUpdate()
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
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
            switch (direction)
            {
                case Directions.Left:
                    if (horizontalInput < 0)
                    {
                        Debug.Log("Left");
                        AudioManager.instance.PlaySFX(1);
                        leftButtonAnimator.SetBool("IsButtonPressed", true);
                        rightButtonAnimator.SetBool("IsButtonPressed", false);
                    }
                    break;
                case Directions.Right:
                    if (horizontalInput > 0)
                    {
                        Debug.Log("Right");
                        AudioManager.instance.PlaySFX(1);
                        leftButtonAnimator.SetBool("IsButtonPressed", false);
                        rightButtonAnimator.SetBool("IsButtonPressed", true);
                    }
                    break;
            }

            return;
        }
        else if (PlayerClawController.instance.moveRight)
        {
            AudioManager.instance.PlaySFX(1);
            leftButtonAnimator.SetBool("IsButtonPressed", false);
            rightButtonAnimator.SetBool("IsButtonPressed", true);

            return;
        }
        else if (PlayerClawController.instance.moveLeft)
        {
            AudioManager.instance.PlaySFX(1);
            leftButtonAnimator.SetBool("IsButtonPressed", true);
            rightButtonAnimator.SetBool("IsButtonPressed", false);

            return;
        }
        else
        {
            AudioManager.instance.soudEffects[1].Stop();
            leftButtonAnimator.SetBool("IsButtonPressed", false);
            rightButtonAnimator.SetBool("IsButtonPressed", false);

            return;
        }

    }
}
