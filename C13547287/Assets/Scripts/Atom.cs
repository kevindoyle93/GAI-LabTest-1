using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    public string electronsPerShell;
    public string atom;

    public GameObject protonPrefab;
    public GameObject electronPrefab;

    public int shellOffset = 3;
    public float electronBaseSpeed = 3;

    private GameObject proton;
    private List<GameObject> electrons = new List<GameObject>();

	void Start ()
    {
        proton = Instantiate(protonPrefab);

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

            GameObject e = Instantiate(electronPrefab, position, transform.rotation);
            Electron electron = e.AddComponent<Electron>();
            electron.speed = electronBaseSpeed + ((shellNumber - 1) * electronBaseSpeed * (shellOffset * 1.5f));
            electron.radius = radius;
            electron.theta = theta;
            electron.thetaInc = thetaInc;
            electrons.Add(e);

            theta += thetaInc;
        }
    }
	
	void Update ()
    {
        	
	}
}
