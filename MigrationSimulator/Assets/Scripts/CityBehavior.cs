using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBehavior : MonoBehaviour {

    float scaler = 1;
    float baseXScale;
    float baseZScale;

	// Use this for initialization
	void Start ()
    {
        baseXScale = this.gameObject.transform.localScale.x;
        baseZScale = this.gameObject.transform.localScale.z;
    }

    public void ScaleCity()
    {
        scaler += 0.05f;
        UpdateScale();
    }
    
    public void DescaleCity()
    {
        scaler -= 0.05f;
        UpdateScale();
    }

    private  void UpdateScale()
    {
        this.gameObject.transform.localScale = new Vector3(baseXScale * scaler,
            1, baseZScale * scaler);
    }
}
