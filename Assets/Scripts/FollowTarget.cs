using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;            // Who this follower is following
    public float followSpeed = 10f;     // How fast to move
    public float followDistance = 1.5f; // Minimum distance behind the target

    void Update()
    {
        if (target == null) return;

        // Direction from this follower to the target
        Vector2 dir = (Vector2)(target.position - transform.position);
        float dist = dir.magnitude;

        // Move only if the follower is further than followDistance
        if (dist > followDistance)
        {
            Vector2 movePos = (Vector2)transform.position + dir.normalized * (dist - followDistance);
            transform.position = Vector2.MoveTowards(transform.position, movePos, followSpeed * Time.deltaTime);
        }
    }
}