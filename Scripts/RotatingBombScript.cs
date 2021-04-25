using UnityEngine;

public class RotatingBombScript : MonoBehaviour
{
    public float rotatingSpeed;
    public float radius;

    private float angle;
    private Vector2 centre;
    private float rand;

    private void Start()
    {
        centre = transform.position;
    }

    private void Update()
    {
        angle += rotatingSpeed * Time.deltaTime;
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = centre + offset;
    }
}