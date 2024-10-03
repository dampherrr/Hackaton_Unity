using UnityEngine;

public class CameraFollow3D : MonoBehaviour
{
    public Transform target;         // Référence du joueur
    public Vector2 minPosition;      // Limites minimales (X, Y)
    public Vector2 maxPosition;      // Limites maximales (X, Y)
    public float smoothing = 0.5f;   // Pour lisser le mouvement

    void LateUpdate()
    {
        if (target != null)
        {
            // Créer une nouvelle position pour la caméra
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Appliquer des limites en X et Y
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            // Mouvement lisse vers la nouvelle position
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}
