using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemblorCamara : MonoBehaviour
{
    public Transform target;
    public float minX, maxX, minY, maxY;
    public float shakeIntensity = 0.1f;
    public float shakeDuration = 0.5f;

    private Vector3 originalPosition;


    private void Start()
    {
        originalPosition = transform.position;
    }

    private void LateUpdate()
    {
        // Obtener la posición actual de la cámara
        Vector3 newPosition = transform.position;

        // Agregar temblor de cámara si se está sacudiendo
        if (shakeDuration > 0)
        {
            newPosition += Random.insideUnitSphere * shakeIntensity;
            shakeDuration -= Time.deltaTime;
        }
        
        // Limitar la posición en el eje X
        newPosition.x = Mathf.Clamp(target.position.x, minX, maxX);

        // Limitar la posición en el eje Y
        newPosition.y = Mathf.Clamp(target.position.y, minY, maxY);

        // Mantener la posición original de la cámara en el eje Z
        newPosition.z = transform.position.z;

        // Actualizar la posición de la cámara
        transform.position = newPosition;
    }

    public void ShakeCamera()
    {
        // Guardar la posición original de la cámara
        originalPosition = transform.position;
        Debug.Log("Llamando shakeCamara");
        // Iniciar el temblor de cámara
        shakeDuration = 0.5f;
        shakeIntensity = 0.1f;
    }
}
