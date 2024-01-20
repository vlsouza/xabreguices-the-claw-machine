using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PlayerClawController : MonoBehaviour
{
    public static PlayerClawController instance;

    public float moveSpeed;
    public float downSpeed;

    public Rigidbody2D clawRigidBody;
    public Rigidbody2D[] prizesRigidBody = new Rigidbody2D[3];

    private bool isGoingDown = false;
    private bool isGoingUp = false;
    private float initialYPosition;
    private float maxYPosition;
    public float maxZRotation;

    private float[] prizesInitialPosition = new float[3];

    public Transform leftClaw;
    public Transform rightClaw;


    public float rotationSpeed = 50f;

    public bool prizeInClaw = false;
    public bool clawOpened = true;
    public bool dropPrize = false;

    //private float maxZRotationCounter = 50f;

    // Start is called before the first frame update
    void Start()
    {
        initialYPosition = clawRigidBody.position.y;
        maxYPosition = initialYPosition - 2f;
        //initalClawsZRotation = rightClaw.rotation.z; //could be any cause both has the same put in different directions but im using right cause is a positive number

        for (int i = 0; i < prizesRigidBody.Length; i++)
        {
            prizesInitialPosition[i] = prizesRigidBody[i].position.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Prize na claw
        if (!clawOpened)
        {
            for (int i = 0; i < prizesRigidBody.Length; i++)
            {
                if (prizesRigidBody[i].position.y > prizesInitialPosition[i] + 1)
                {
                    Debug.Log("Prize!");
                    prizeInClaw = true;
                    break;
                }
            }
        } else // se claw estiver aberta, nunca procurar por prize
        {
            prizeInClaw = false;
        }

        // Mudar o estado da garra apenas se ela não estiver atualmente se movendo para baixo ou para cima
        if (!isGoingDown && !isGoingUp)
        {
            // GetAxisRaw faz o personagem andar sem deslizar pois pega o X ou Y sem a a graduação do input em "Project settings"
            clawRigidBody.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), clawRigidBody.velocity.y);
        }

        if (Input.GetButtonDown("Submit"))
        {
            if (!prizeInClaw)
            {
                // Mudar o estado da garra apenas se ela não estiver atualmente se movendo para baixo
                if (!isGoingDown && !isGoingUp)
                {
                    isGoingDown = true;
                }
                else if (isGoingDown)
                {
                    isGoingDown = false;
                    isGoingUp = true;
                }
            }
            else if (prizeInClaw && !isGoingDown && !isGoingUp)
            {
                dropPrize = true;
            }
        }

        if (isGoingDown)
        {
            clawOpened = false;
            GoDown();
        }

        if (isGoingUp)
        {
            GoUp();
        }

        // if not going down or going up and no prizes in the claw, open the claw
        if (!isGoingDown && !isGoingUp && !clawOpened)
        {
            if (!prizeInClaw)
            {
                OpenClaws();
            } else if (prizeInClaw && dropPrize)
            {
                OpenClaws();
            }
        }
    }
    void OpenClaws()
    {
        if (rightClaw.rotation.z >= 0.50) // se claw está aberta, não tem prize e nem comando drop
        {

            dropPrize = false;
            clawOpened = true;
        }
        else
        {
            var rotation = maxZRotation - rightClaw.rotation.z;
            RotateClaw(leftClaw, -rotation);
            RotateClaw(rightClaw, rotation);
        }
    }

    void GoUp()
    {
        // Move de volta ao ponto de partida
        float newYPosition = Mathf.MoveTowards(clawRigidBody.position.y, initialYPosition, downSpeed * Time.deltaTime);
        clawRigidBody.MovePosition(new Vector2(clawRigidBody.position.x, newYPosition));

        // Se atingiu a posição inicial, muda o estado para parar
        if (Mathf.Approximately(newYPosition, initialYPosition))
        {
            isGoingUp = false;
        }
    }

    void GoDown()
    {
        // Move para baixo até a posição maxYPosition
        float newYPosition = Mathf.MoveTowards(clawRigidBody.position.y, maxYPosition, downSpeed * Time.deltaTime);
        clawRigidBody.MovePosition(new Vector2(clawRigidBody.position.x, newYPosition));

        // Rotate the left claw
        RotateClaw(leftClaw, newYPosition);

        // Rotate the right claw (you may need to invert the input if necessary)
        RotateClaw(rightClaw, -newYPosition);

        // Se atingiu a posição maxYPosition, muda o estado para subir
        if (Mathf.Approximately(newYPosition, maxYPosition))
        {
            isGoingDown = false;
            isGoingUp = true;
        }
    }

    void RotateClaw(Transform claw, float input)
    {
        // Calculate the rotation amount based on input and speed
        float rotationAmount = input * rotationSpeed * Time.deltaTime;

        // Rotate the claw around its local axis (you may need to adjust the axis)
        claw.Rotate(Vector3.forward, rotationAmount);
    }
}
