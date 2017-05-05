using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    public string electronsPerShell;
    public string atom;

    public GameObject protonPrefab;
    public GameObject electronPrefab;

    public int shellOffset = 2;
    public float electronBaseSpeed = 0.25f;

    private GameObject proton;

	void Start ()
    {
        proton = Instantiate(protonPrefab, transform);
        proton.transform.position = transform.position;

        string[] electrons = electronsPerShell.Split(',');
        for (int i = 0; i < electrons.Length; i++)
        {
            CreateElectronShell(i + 1, int.Parse(electrons[i]));
        }
	}

    private void CreateElectronShell (int shellNumber, int numElectrons)
    {
        float radius = shellOffset * shellNumber;

        float theta = 0;
        float thetaInc = (2 * Mathf.PI) / numElectrons;

        for (int i = 0; i < numElectrons; i++)
        {
            Vector3 position = new Vector3(Mathf.Sin(theta), transform.position.y, -Mathf.Cos(theta));
            position *= radius;

            GameObject e = Instantiate(electronPrefab, transform);
            e.transform.position += transform.position;
            Boid electron = e.GetComponent<Boid>();
            electron.radius = radius;
            electron.theta = theta;
            electron.maxSpeed = electronBaseSpeed + ((shellNumber - 1) * electronBaseSpeed * (shellOffset));

            theta += thetaInc;
        }
    }
	
	void Update ()
    {
        	
	}
}
