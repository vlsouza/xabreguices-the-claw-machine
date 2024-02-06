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
        //// Posiciona o cursor na posi��o do mouse
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePosition.z = 0f; // Garante que o cursor est� na mesma profundidade
        //transform.position = mousePosition;

        // Verifica se h� toques na tela
        if (Input.touchCount > 0)
        {
            // Obt�m a posi��o do primeiro toque
            Touch touch = Input.GetTouch(0);

            // Converte a posi��o do toque para o mundo
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f; // Garante que o cursor est� na mesma profundidade

            // Atualiza a posi��o do cursor
            transform.position = touchPosition;
        }
        // Se n�o houver toques, verifica a posi��o do mouse
        else if (Input.mousePresent)
        {
            // Posiciona o cursor na posi��o do mouse
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Garante que o cursor est� na mesma profundidade

            // Atualiza a posi��o do cursor
            transform.position = mousePosition;
        }
    }
}
