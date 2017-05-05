using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 force, velocity, acceleration;

    public float speed;

    public float theta, thetaInc, radius;

	void Start ()
    {
		
	}

    public Vector3 Orbit()
    {
        theta += thetaInc * (Time.deltaTime / 10.0f) * speed;

        Vector3 desired = new Vector3(Mathf.Sin(theta), transform.position.y, -Mathf.Cos(theta));
        desired *= radius;

        return desired - velocity;
    }
	
	void Update ()
    {
        force = Vector3.zero;
        force += Orbit();
        
        transform.position = force;
	}
}
