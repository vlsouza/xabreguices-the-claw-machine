using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SubmitController : MonoBehaviour
{
    public Animator submitButtonAnimator;

    // Update is called once per frame
    void Update()
    {
        if (PlayerClawController.instance.state == PlayerClawController.States.GOING_DOWN)
        {
            submitButtonAnimator.SetBool("IsButtonPressed", true);
        } 
        else if (PlayerClawController.instance.state == PlayerClawController.States.DEFAULT_WITH_PRIZE)  
        {
            submitButtonAnimator.SetBool("IsButtonPressed", true);
        }
        else if (PlayerClawController.instance.state == PlayerClawController.States.DEFAULT)
        {
            submitButtonAnimator.SetBool("IsButtonPressed", false);
        }
    }
}
