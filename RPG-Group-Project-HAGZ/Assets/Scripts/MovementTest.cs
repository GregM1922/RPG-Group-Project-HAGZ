using UnityEngine;

public class NPCMovement2D : MonoBehaviour
{
    public Transform target; // Target to move towards
    public float speed = 3f; // Movement speed
    public float stopDistance = 1f; // Distance at which NPC stops near the target

    void Update()
    {
        if (target == null)
        {
            return; // Exit if no target assigned
        }

        // Calculate direction towards the target
        Vector3 direction = target.position - transform.position;

        // Ignore Z-axis since it's 2D
        direction.z = 0;

        // Move the NPC if it's farther than the stop distance
        if (direction.magnitude > stopDistance)
        {
            // Normalize direction and move
            Vector3 move = direction.normalized * speed * Time.deltaTime;
            transform.position += move;

            // Optional: Flip the sprite based on the direction (for left/right facing sprites)
            if (direction.x != 0)
            {
                Vector3 localScale = transform.localScale;
                localScale.x = direction.x > 0 ? Mathf.Abs(localScale.x) : -Mathf.Abs(localScale.x);
                transform.localScale = localScale;
            }
        }
    }
}
