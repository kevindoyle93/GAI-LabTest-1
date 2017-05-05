using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 force, velocity, acceleration;

    public float maxSpeed;

    public float theta, radius;

	void Start ()
    {
		
	}

    public Vector3 Orbit()
    {
        theta += Time.deltaTime;

        Vector3 target = new Vector3(Mathf.Sin(theta), transform.position.y, -Mathf.Cos(theta));
        target *= radius;

        return Seek(target);
    }

    void OrbitWithoutSeek()
    {
        theta += Time.deltaTime * maxSpeed;

        Vector3 target = new Vector3(Mathf.Sin(theta), transform.position.y, -Mathf.Cos(theta));
        target *= radius;

        transform.position = target;
    }

    Vector3 Seek(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= maxSpeed;

        return desired - velocity;
    }

    Vector3 Wander()
    {

        return Vector3.zero;
    }
	
	void Update ()
    {
        OrbitWithoutSeek();

        force = Vector3.zero;
        // force += Orbit();

        float smoothAccelerationRate = Mathf.Clamp(9.0f * Time.deltaTime, 0.15f, 0.4f) / 2.0f;
        acceleration = Vector3.Lerp(acceleration, force, smoothAccelerationRate);

        velocity += acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        Vector3 globalUp = new Vector3(0, 0.2f, 0);
        Vector3 accelerationUp = acceleration * 0.05f;
        Vector3 bankingUp = globalUp + acceleration;

        float smoothBankingRate = 3 * Time.deltaTime;
        Vector3 tempUp = Vector3.Lerp(transform.up, bankingUp, smoothBankingRate);

        if (velocity.magnitude > 0.0001f)
        {
            transform.LookAt(transform.position + velocity, tempUp);
            velocity *= 0.99f;
        }

        transform.position += velocity * Time.deltaTime;
	}
}
