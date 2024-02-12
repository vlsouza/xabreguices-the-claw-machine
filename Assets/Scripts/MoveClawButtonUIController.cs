using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class MoveClawButtonUIController : MonoBehaviour
{
    public MoveClawButtonController.Directions direction;

    public void OnPointerDownButton()
    {
        Debug.Log("Tela tocada no bot�o! Down");
        switch (direction)
        {
            case MoveClawButtonController.Directions.Left:
                PlayerClawController.instance.moveLeft = true;
                PlayerClawController.instance.moveRight = false;
                break;
            case MoveClawButtonController.Directions.Right:
                PlayerClawController.instance.moveRight = true;
                PlayerClawController.instance.moveLeft = false;
                break;
        }
    }

    public void OnPointerUpButton()
    {
        Debug.Log("Tela tocada no bot�o! Up");
        switch (direction)
        {
            case MoveClawButtonController.Directions.Left:
                PlayerClawController.instance.moveLeft = false;
                PlayerClawController.instance.moveRight = false;
                break;
            case MoveClawButtonController.Directions.Right:
                PlayerClawController.instance.moveLeft = false;
                PlayerClawController.instance.moveRight = false;
                break;
        }
    }
}
