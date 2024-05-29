using UnityEngine;

public class EnemyFieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    private LineRenderer lineRenderer;
    private int resolution = 50; 

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = resolution + 1; 
    }

    void Update()
    {
        DrawFieldOfView();
    }

    void DrawFieldOfView()
    {
        float angleStep = viewAngle / resolution;
        for (int i = 0; i <= resolution; i++)
        {
            float angle = transform.eulerAngles.y - viewAngle / 2 + angleStep * i;
            Vector3 direction = DirFromAngle(angle, false);
            lineRenderer.SetPosition(i, transform.position + direction * viewRadius);
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    }
}
