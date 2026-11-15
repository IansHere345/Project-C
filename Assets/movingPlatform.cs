using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed = 10f;
    [SerializeField] float waitTime = 1f;

    public Vector3 Velocity { get; private set; }   // for riders
    public Vector3 Delta { get; private set; }      // movement this physics step

    Rigidbody rb;
    int index;
    float waitTimer;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void FixedUpdate()
    {
        Vector3 next = rb.position;

        if (waitTimer > 0f)
        {
            waitTimer -= Time.fixedDeltaTime;
        }
        else
        {
            Vector3 target = waypoints[index].position;
            next = Vector3.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            if ((next - target).sqrMagnitude < 0.0001f)
            {
                index = (index + 1) % waypoints.Length;
                waitTimer = waitTime;
            }
        }

        // MovePosition applies during the physics step, so record the intended movement
        Delta = next - rb.position;
        Velocity = Delta / Time.fixedDeltaTime;
        rb.MovePosition(next);
    }

    void OnDrawGizmos()
    {
        if (waypoints == null) return;
        Gizmos.color = Color.cyan;
        for (int i = 0; i < waypoints.Length; i++)
            if (waypoints[i] && waypoints[(i + 1) % waypoints.Length])
                Gizmos.DrawLine(waypoints[i].position, waypoints[(i + 1) % waypoints.Length].position);
    }
}
//Source Used: https://devforgeunity.com/unity-moving-platforms/
