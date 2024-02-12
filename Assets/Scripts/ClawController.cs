using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    public float targetRotation;
    public float openRotationSpeed = 2f;
    public float closeRotationSpeed = 2f;

    private Quaternion initalRotation;
    public Quaternion targetRotationQuaternion;

    // Start is called before the first frame update
    void Start()
    {
        initalRotation = transform.rotation;
        targetRotationQuaternion = new Quaternion(transform.rotation.x, transform.rotation.y, targetRotation, transform.rotation.w);
    }

    public void OpenClaw()
    {
        // Obtenha a rota��o atual do objeto
        Quaternion currentRotation = transform.rotation;

        // Interpole a rota��o atual em dire��o � rota��o desejada usando Slerp
        Quaternion newRotation = Quaternion.Slerp(currentRotation, initalRotation, openRotationSpeed * Time.deltaTime);

        // Atribua a nova rota��o ao objeto
        transform.rotation = newRotation;
    }

    public void CloseClaw()
    {
        // Obtenha a rota��o atual do objeto
        Quaternion currentRotation = transform.rotation;

        // Interpole a rota��o atual em dire��o � rota��o desejada usando Slerp
        Quaternion newRotation = Quaternion.Slerp(currentRotation, targetRotationQuaternion, closeRotationSpeed * Time.deltaTime);

        // Atribua a nova rota��o ao objeto
        transform.rotation = newRotation;
    }
}
