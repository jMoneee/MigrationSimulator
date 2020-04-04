using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Camera cam;
	// Use this for initialization
	void Start ()
    {
        cam.transform.localPosition = this.gameObject.transform.GetChild(0).transform.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("1")) cam.transform.localPosition = this.gameObject.transform.GetChild(0).transform.localPosition;
        if (Input.GetKeyDown("2")) cam.transform.localPosition = this.gameObject.transform.GetChild(1).transform.localPosition;
        if (Input.GetKeyDown("3")) cam.transform.localPosition = this.gameObject.transform.GetChild(2).transform.localPosition;
        if (Input.GetKeyDown("4")) cam.transform.localPosition = this.gameObject.transform.GetChild(3).transform.localPosition;
        if (Input.GetKeyDown("5")) cam.transform.localPosition = this.gameObject.transform.GetChild(4).transform.localPosition;
    }
}
