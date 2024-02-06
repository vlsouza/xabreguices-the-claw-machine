using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class MoveClawCrontoller : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento
    public Animator rightButtonAnimator;
    public Animator leftButtonAnimator;
    private bool touchPressed = false;

    public enum Directions
    {
        Left,
        Right
    }

    public Directions direction;

    void Start()
    {
        // Encontre o bot�o no objeto atual
        Button btn = GetComponent<Button>();
        // Adicione um listener para chamar a fun��o quando o bot�o � pressionado
        //btn.onClick.AddListener(Mover);
    }
    void Update()
    {
        // Move o Rigidbody2D se o toque estiver sendo pressionado
        if (touchPressed)
        {
            Move(direction);
        }
    }

    public void Move(Directions direction)
    {
        switch (direction)
        {
            case Directions.Left:
                Debug.Log("Esquerda");
                //PlayerClawController.instance.clawRigidBody.velocity = new Vector2(Vector2.left.x * moveSpeed, PlayerClawController.instance.clawRigidBody.velocity.y);
                //rightButtonAnimator.SetBool("IsButtonPressed", false);
                //leftButtonAnimator.SetBool("IsButtonPressed", true);
                break;
            case Directions.Right:
                //PlayerClawController.instance.clawRigidBody.velocity = new Vector2(Vector2.right.x * moveSpeed, PlayerClawController.instance.clawRigidBody.velocity.y);
                Debug.Log("Direita");
                Input.GetKeyDown(KeyCode.RightArrow);
                ////rightButtonAnimator.SetBool("IsButtonPressed", true);
                ////leftButtonAnimator.SetBool("IsButtonPressed", false);
                break;
        }
    }

    // Fun��o a ser chamada quando o bot�o � pressionado
    public void OnButtonDown()
    {
        touchPressed = true;
    }

    //Fun��o a ser chamada quando o bot�o � solto
    public void OnButtonUp()
    {
        rightButtonAnimator.SetBool("IsButtonPressed", false);
        leftButtonAnimator.SetBool("IsButtonPressed", false);
        touchPressed = false;
        PlayerClawController.instance.clawRigidBody.velocity = new Vector2(0, PlayerClawController.instance.clawRigidBody.velocity.y);
    }

    // Fun��o a ser chamada quando o bot�o � pressionado via toque
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("Bot�o Pressionado");
    //    touchPressed = true;
    //    Move(direction);
    //}

    //// Fun��o a ser chamada quando o bot�o � solto via toque
    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    Debug.Log("Bot�o Solto");
    //    touchPressed = false;
    //    clawRigidBody2D.velocity = new Vector2(0, clawRigidBody2D.velocity.y);
    //}
}
