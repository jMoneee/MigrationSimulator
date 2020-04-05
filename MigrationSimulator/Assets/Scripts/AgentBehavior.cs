using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentBehavior : MonoBehaviour {

    float timer = 0;
    string target = "";
    Vector3 prevPosition;
    bool flag = false;

    GameObject agentDriver;
	// Use this for initialization
	void Start () {
        prevPosition = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (true)
        {
            if (prevPosition == this.gameObject.transform.position)
                Destroy(this.gameObject);
        }
        flag = true;
        prevPosition = this.gameObject.transform.position;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == target)
        {
            collision.gameObject.GetComponent<CityBehavior>().ScaleCity();
            Destroy(this.gameObject);
        }
    }

    public void SetTarget(string t) { target = t; }
}
