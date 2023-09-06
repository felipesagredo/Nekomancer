using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float minX, maxX, minY, maxY;

    private void LateUpdate()
    {
        // Obtener la posición actual de la cámara
        Vector3 newPosition = transform.position;
        
        // Limitar la posición en el eje X
        newPosition.x = Mathf.Clamp(target.position.x, minX, maxX);

        // Limitar la posición en el eje Y
        newPosition.y = Mathf.Clamp(target.position.y, minY, maxY);

        // Mantener la posición original de la cámara en el eje Z
        newPosition.z = transform.position.z;

        // Actualizar la posición de la cámara
        transform.position = newPosition;
    }
}