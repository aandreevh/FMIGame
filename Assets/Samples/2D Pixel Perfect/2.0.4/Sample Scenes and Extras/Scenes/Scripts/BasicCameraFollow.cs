using UnityEngine;

public class BasicCameraFollow : MonoBehaviour
{
    public GameObject followTarget;
    public float moveSpeed;
    private Vector3 targetPos;

    private void Update()
    {
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y,
            transform.position.z);
        var velocity = targetPos - transform.position;
        transform.position =
            Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 1.0f, moveSpeed * Time.deltaTime);
    }
}