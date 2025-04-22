using UnityEngine;

public class SpawnPointMarker : MonoBehaviour
{
    public Color gizmoColor = Color.green; // Default color for spawn points
    public float gizmoSize = 0.5f; // Size of the gizmo sphere

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, gizmoSize);
    }
}
