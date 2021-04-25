using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public float moveSpeed = 10f;
    public GameObject[] checkpoints;
    public float distance = 2f;
    public int counter = 0;
    public Rigidbody2D rb;

    void FixedUpdate()
    {
        Vector3 direction = Vector3.zero;
        direction = checkpoints[counter].transform.position - rb.transform.position;
        if (direction.magnitude < distance)
        {
            if (counter < checkpoints.Length - 1)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }
        }
        direction = direction.normalized;
        Vector3 dir = direction;

        rb.velocity = new Vector2(direction.x * moveSpeed * Time.deltaTime, direction.y * moveSpeed * Time.deltaTime);
    }
}