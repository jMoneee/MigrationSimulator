using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartAndGraph;

public class IncarcerationGraphUpdate : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        BarChart barChart = GetComponent<ChartAndGraph.BarChart>();
        barChart.DataSource.SetValue("Number Incarcerated","Migrant Population", 50);
        barChart.DataSource.SetValue("Number Incarcerated", "Native Population", 500);
    }
}
