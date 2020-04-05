using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartAndGraph;


public class UpdateIncGraph : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        BarChart barChart = GetComponent<BarChart>();
        //if (barChart != null) {
        //barChart.DataSource.SlideValue( "Some HS", "Native Born", 20, 4f);
        barChart.DataSource.SetValue("Native Born", "All", MigrationFramework.getSpecificPopValue("usInc") / 1000);        barChart.DataSource.SetValue("Legal Migrant", "All", MigrationFramework.getSpecificPopValue("frLegalInc") / 1000);
        barChart.DataSource.SetValue("Illegal Migrant", "All", MigrationFramework.getSpecificPopValue("frIllegalInc") / 1000);
        
        //}
    }
}

