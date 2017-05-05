using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    public string electronsPerShell;
    public string atom;

    public GameObject protonPrefab;
    public GameObject electronPrefab;

    public int shellOffset = 15;

	void Start ()
    {
        Instantiate(protonPrefab);

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
            Instantiate(electronPrefab, position, transform.rotation);

            theta += thetaInc;
        }
    }
	
	void Update ()
    {
		
	}
}
