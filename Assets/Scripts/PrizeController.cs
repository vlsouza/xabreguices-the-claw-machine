using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeController : MonoBehaviour
{
    public Rigidbody2D prizeRigidBody2D;

    private float initialYPosition;
    public Transform prizeGotLine;

    // Start is called before the first frame update
    void Start()
    {
        initialYPosition = prizeRigidBody2D.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (prizeRigidBody2D.position.y > prizeGotLine.position.y)
        {
            PlayerClawController.instance.prizeInClaw = true;
        }
    }
}
