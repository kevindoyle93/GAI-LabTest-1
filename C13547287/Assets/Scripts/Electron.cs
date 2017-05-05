using UnityEngine;

public class Electron : MonoBehaviour
{
    public float speed;
    public float radius;
    public float theta;
    public float thetaInc;

    void Update()
    {
        theta += thetaInc * (Time.deltaTime / 10.0f) * speed;

        Vector3 target = new Vector3(Mathf.Sin(theta), transform.position.y, -Mathf.Cos(theta));
        target *= radius;

        transform.position = target;
    }
}
