using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartAndGraph;

public class UpdateEdGraph : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        BarChart barChart = GetComponent<BarChart>();
       
        barChart.DataSource.SetValue("Below HS", "Foreign Born", MigrationFramework.getSpecificPopValue("frLessThanHighschool") / 1000);
        barChart.DataSource.SetValue( "Some HS", "Foreign Born", MigrationFramework.getSpecificPopValue("frHighschool")/1000);        barChart.DataSource.SetValue("HS Grad", "Foreign Born", MigrationFramework.getSpecificPopValue("frHighschoolGrad") / 1000);
        barChart.DataSource.SetValue("Some College", "Foreign Born", MigrationFramework.getSpecificPopValue("frTwoYear") / 1000);
        barChart.DataSource.SetValue("Bachelors", "Foreign Born", MigrationFramework.getSpecificPopValue("frBachelors") / 1000);
        barChart.DataSource.SetValue("Other", "Foreign Born", MigrationFramework.getSpecificPopValue("frOther") / 1000);

        barChart.DataSource.SetValue("Below HS", "Native Born", MigrationFramework.getSpecificPopValue("usLessThanHighschool") / 1000);
        barChart.DataSource.SetValue("Some HS", "Native Born", MigrationFramework.getSpecificPopValue("usHighschool") / 1000);        barChart.DataSource.SetValue("HS Grad", "Native Born", MigrationFramework.getSpecificPopValue("usHighschoolGrad") / 1000);
        barChart.DataSource.SetValue("Some College", "Native Born", MigrationFramework.getSpecificPopValue("usTwoYear") / 1000);
        barChart.DataSource.SetValue("Bachelors", "Native Born", MigrationFramework.getSpecificPopValue("usBachelors") / 1000);
        barChart.DataSource.SetValue("Other", "Native Born", MigrationFramework.getSpecificPopValue("usOther") / 1000);
        
    }
}
