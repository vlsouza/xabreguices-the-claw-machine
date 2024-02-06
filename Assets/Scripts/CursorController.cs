using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Hide the cursor
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //// Posiciona o cursor na posição do mouse
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePosition.z = 0f; // Garante que o cursor está na mesma profundidade
        //transform.position = mousePosition;

        // Verifica se há toques na tela
        if (Input.touchCount > 0)
        {
            // Obtém a posição do primeiro toque
            Touch touch = Input.GetTouch(0);

            // Converte a posição do toque para o mundo
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f; // Garante que o cursor está na mesma profundidade

            // Atualiza a posição do cursor
            transform.position = touchPosition;
        }
        // Se não houver toques, verifica a posição do mouse
        else if (Input.mousePresent)
        {
            // Posiciona o cursor na posição do mouse
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Garante que o cursor está na mesma profundidade

            // Atualiza a posição do cursor
            transform.position = mousePosition;
        }
    }
}
