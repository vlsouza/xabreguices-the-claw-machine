using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class PlayerClawController : MonoBehaviour
{
    public static PlayerClawController instance;

    public Rigidbody2D playerClawRigidBody;
    public ClawController leftClawController;
    public ClawController rightClawController;

    public float initialYPosition;
    private float maxYPosition;

    public float moveSpeed;
    public float downSpeed;

    public bool prizeInClaw = false;
    public bool moveRight = false;
    public bool moveLeft = false;

    public enum States
    {
        DEFAULT,
        DEFAULT_WITH_PRIZE,
        GOING_DOWN,
        GOING_UP,
    }

    public States state = States.DEFAULT;

    public bool isSubmitted;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        AudioManager.instance.PlayGameplayTheme(1);
        initialYPosition = playerClawRigidBody.position.y;
        maxYPosition = initialYPosition - 2.5f;
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            isSubmitted = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case States.DEFAULT:
                prizeInClaw = false;
                MoveClaw();
                OpenClaws();
                if (isSubmitted)
                {
                    state = States.GOING_DOWN;
                }
                isSubmitted = false;
                break;
            case States.DEFAULT_WITH_PRIZE:
                MoveClaw();
                CloseClaws();
                if (isSubmitted)
                {
                    AudioManager.instance.PlaySFX(0);
                    state = States.DEFAULT;
                }
                isSubmitted = false;
                break;
            case States.GOING_DOWN:
                AudioManager.instance.PlaySFX(2);
                GoDown();
                CloseClaws();

                isSubmitted = false;
                break;
            case States.GOING_UP:
                AudioManager.instance.PlaySFX(2);
                isSubmitted = false;

                if (!prizeInClaw)
                {
                    GoUp(States.DEFAULT);
                } else
                {
                    GoUp(States.DEFAULT_WITH_PRIZE);
                }
                
                CloseClaws();
                break;
        }
    }

    private void OpenClaws()
    {
        leftClawController.OpenClaw();
        rightClawController.OpenClaw();
    }

    private void CloseClaws()
    {
        leftClawController.CloseClaw();
        rightClawController.CloseClaw();
    }

    public void MoveClaw()
    {
        MoveClawByInput();

        if (moveRight)
        {
            MoveClawRight();
        }
        else if (moveLeft)
        {
            MoveClawLeft();
        }
    }

    public void MoveClawByInput()
    {
        playerClawRigidBody.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), playerClawRigidBody.velocity.y);
    }

    public void MoveClawLeft()
    {
        //Debug.Log("Esquerda");
        playerClawRigidBody.velocity = new Vector2(-moveSpeed, playerClawRigidBody.velocity.y);
    }

    public void MoveClawRight()
    {
        //Debug.Log("Direita");
        playerClawRigidBody.velocity = new Vector2(moveSpeed, playerClawRigidBody.velocity.y);
    }

    public void PointerDownGoDown()
    {
        if (state == States.DEFAULT)
        {
            state = States.GOING_DOWN;
        } 
        else if (state == States.DEFAULT_WITH_PRIZE)
        {
            AudioManager.instance.PlaySFX(0);
            state = States.DEFAULT;
        } 
    }

    void GoUp(States nextState)
    {
        // Move de volta ao ponto de partida
        float newYPosition = Mathf.MoveTowards(playerClawRigidBody.position.y, initialYPosition, downSpeed * Time.deltaTime);
        playerClawRigidBody.MovePosition(new Vector2(playerClawRigidBody.position.x, newYPosition));

        // Se atingiu a posição inicial, muda o estado para parar
        if (Mathf.Approximately(newYPosition, initialYPosition))
        {
            state = nextState;
        }
    }

    void GoDown()
    {
        // Move para baixo até a posição maxYPosition
        float newYPosition = Mathf.MoveTowards(playerClawRigidBody.position.y, maxYPosition, downSpeed * Time.deltaTime);
        playerClawRigidBody.MovePosition(new Vector2(playerClawRigidBody.position.x, newYPosition));

        // Se atingiu a posição maxYPosition, muda o estado para subir
        if (Mathf.Approximately(newYPosition, maxYPosition))
        {
            state = States.GOING_UP;
        }
    }
}
