using UnityEngine;

public class GizmoDrawing : MonoBehaviour
{
    public bool lightningbolt = true;
    public bool chainlightning = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnDrawGizmos()
    {
        if (lightningbolt)
        {
            Vector3 pointInFront = transform.position + transform.forward * 15f;
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(pointInFront, 5f);
        }
        if (chainlightning)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(transform.position, 5f);
        }

    }
}
