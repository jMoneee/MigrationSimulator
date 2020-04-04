using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentDriver : MonoBehaviour {

    public GameObject foreignPrefab;
    public GameObject nativePrefab;

    public GameObject[] cities;
    float timer = 1;

    // Use this for initialization
    void Start ()
    {
        cities = GameObject.FindGameObjectsWithTag("City");
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            timer = 0;
            int r = (int)Random.Range(1, 6);
            for (int i = 0; i < r; i++)
            {
                int choice = (int)Random.Range(0, 2);
                if (choice == 0)
                {
                    GameObject temp = Instantiate<GameObject>(foreignPrefab,
                        cities[Random.Range(0, cities.Length)].transform.position, new Quaternion(90, 0, 0, 0));
                    temp.GetComponent<NavMeshAgent>().SetDestination(cities[Random.Range(0, cities.Length)].transform.position);
                }
                else if (choice == 1)
                {
                    GameObject temp = Instantiate<GameObject>(nativePrefab,
                        cities[Random.Range(0, cities.Length)].transform.position, new Quaternion(90, 0, 0, 0));
                    temp.GetComponent<NavMeshAgent>().SetDestination(cities[Random.Range(0, cities.Length)].transform.position);
                }
            }
        }
	}
}
