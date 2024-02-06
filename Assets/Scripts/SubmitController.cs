using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SubmitController : MonoBehaviour
{
    public static SubmitController instance;

    public bool submitted = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            // Loop through all touches
            for (int i = 0; i < Input.touchCount; i++)
            {
                // Get the current touch
                Touch touch = Input.GetTouch(i);

                // Check if the touch is on our specific GameObject
                if (IsTouchOnObject(touch.position))
                {
                    submitted = true;
                    // Perform actions specific to your GameObject
                    Debug.Log("Touch detected on the GameObject!");
                }
            }
        }
    }

    bool IsTouchOnObject(Vector2 touchPosition)
    {
        // Convert screen position to world position
        Vector2 worldTouchPosition = Camera.main.ScreenToWorldPoint(touchPosition);

        // Perform a raycast to check if the touch is on this GameObject
        RaycastHit2D hit = Physics2D.Raycast(worldTouchPosition, Vector2.zero);

        // Check if the raycast hit this GameObject
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            return true;
        }

        Debug.Log("False!");
        return false;
    }
}
