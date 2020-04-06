using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject ri;

    public Camera cam;
    bool regionOn = true;
	// Use this for initialization
	void Start ()
    {
        SwitchOnRegionCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if (regionOn)
        {
            if (Input.GetKeyDown("1")) cam.transform.localPosition = this.gameObject.transform.GetChild(0).transform.localPosition;
            if (Input.GetKeyDown("2")) cam.transform.localPosition = this.gameObject.transform.GetChild(1).transform.localPosition;
            if (Input.GetKeyDown("3")) cam.transform.localPosition = this.gameObject.transform.GetChild(2).transform.localPosition;
            if (Input.GetKeyDown("4")) cam.transform.localPosition = this.gameObject.transform.GetChild(3).transform.localPosition;
            if (Input.GetKeyDown("5")) cam.transform.localPosition = this.gameObject.transform.GetChild(4).transform.localPosition;
        }
    }

    public void SwitchOffRegionCamera()
    {
        cam.transform.localPosition = this.gameObject.transform.GetChild(5).transform.localPosition;
    }

    public void SwitchOnRegionCamera()
    {
        regionOn = true;
        cam.transform.localPosition = this.gameObject.transform.GetChild(0).transform.localPosition;
    }
}
