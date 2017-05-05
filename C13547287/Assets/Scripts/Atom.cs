using UnityEngine;

public class Atom : MonoBehaviour
{
    public string electronsPerShell;
    public string atom;

    public GameObject protonPrefab;
    public GameObject electronPrefab;

	void Start ()
    {
        Instantiate(protonPrefab);
	}
	
	void Update ()
    {
		
	}
}
