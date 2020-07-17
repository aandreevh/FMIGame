using UnityEngine;

public class HeroMover : MonoBehaviour
{
    public float Amplitude = 1.0f;
    public float Frequency = 1.0f;
    private float offset;

    private Vector3 origin;


    // Use this for initialization
    private void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        offset = Mathf.Sin(Time.time * Frequency * 4.0f) * Amplitude;
        transform.position = origin + Vector3.right * offset;
    }
}