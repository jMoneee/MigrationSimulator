using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartAndGraph;

public class UpdateUnEmpGraph : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        BarChart barChart = GetComponent<BarChart>();
        
        barChart.DataSource.SetValue("Unemployed", "Native Born", MigrationFramework.getSpecificPopValue("usUnEm") / 1000);        barChart.DataSource.SetValue("Not in Workforce", "Native Born", MigrationFramework.getSpecificPopValue("usNotWorking") / 1000);
        barChart.DataSource.SetValue("Unemployed", "Foreign Born", MigrationFramework.getSpecificPopValue("frUnEm") / 1000);
        barChart.DataSource.SetValue("Not in Workforce", "Foreign Born", MigrationFramework.getSpecificPopValue("frNotWorking") / 1000);
    }
}
