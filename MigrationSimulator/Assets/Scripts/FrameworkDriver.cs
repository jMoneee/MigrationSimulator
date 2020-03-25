using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameworkDriver : MonoBehaviour {

    public Text migrantsText;

    public Text usEdText;
    public Text frEdText;

    public Text usIncText;
    public Text frIncText;

    public Text usUnemText;
    public Text frUnemText;

    // Use this for initialization
    void Start ()
    {
        updateAllData();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void incrementYear()
    {
        MigrationFramework.yearlyPopUpdate();
        updateAllData();
    }

    public void newPolicy(float us, float fr)
    {
        MigrationFramework.implementNewPolicy(us, fr);
        updateAllData();
    }

    public long getPop(int key)
    {
        switch (key)
        {
            case 1:
                return MigrationFramework.getFrPop();
            case 2:
                return MigrationFramework.getUsPop();
            default:
                return -1;
        }
    }

    private void updateAllData()
    {
        migrantsText.text = "NE Migrants: " + MigrationFramework.getSpecificPopValue("neMigrants")
            + "\nMW Migrants: " + MigrationFramework.getSpecificPopValue("mwMigrants")
            + "\nSouth Migrants: " + MigrationFramework.getSpecificPopValue("sMigrants")
            + "\nWest Migrants: " + MigrationFramework.getSpecificPopValue("wMigrants");

        usEdText.text = "Less than High School: " + MigrationFramework.getSpecificPopValue("usLessThanHighschool")
            + "\nSome High School: " + MigrationFramework.getSpecificPopValue("usHighschool")
            + "\nHigh School Diploma: " + MigrationFramework.getSpecificPopValue("usHighschoolGrad")
            + "\nTwo Year Diploma: " + MigrationFramework.getSpecificPopValue("usTwoYear")
            + "\nBachelors Diploma: " + MigrationFramework.getSpecificPopValue("usBachelors")
            + "\nOther: " + MigrationFramework.getSpecificPopValue("usOther");

        frEdText.text = "Less than High School: " + MigrationFramework.getSpecificPopValue("frLessThanHighschool")
            + "\nSome High School: " + MigrationFramework.getSpecificPopValue("frHighschool")
            + "\nHigh School Diploma: " + MigrationFramework.getSpecificPopValue("frHighschoolGrad")
            + "\nTwo Year Diploma: " + MigrationFramework.getSpecificPopValue("frTwoYear")
            + "\nBachelors Diploma: " + MigrationFramework.getSpecificPopValue("frBachelors")
            + "\nOther: " + MigrationFramework.getSpecificPopValue("frOther");

        usIncText.text = "Incarceration Number: " + MigrationFramework.getSpecificPopValue("usInc");

        frIncText.text = "Incarceration Number: " + MigrationFramework.getSpecificPopValue("frInc")
            + "\nLegal Incarceration: " + MigrationFramework.getSpecificPopValue("frLegalInc")
            + "\nIllegal Incarceration: " + MigrationFramework.getSpecificPopValue("frIllegalInc");

        usUnemText.text = "Unemployment Number: " + MigrationFramework.getSpecificPopValue("usUnEm")
            + "\nOut of Work Force: " + MigrationFramework.getSpecificPopValue("usNotWorking");

        frUnemText.text = "Unemployment Number: " + MigrationFramework.getSpecificPopValue("frUnEm")
            + "\nOut of Work Force: " + MigrationFramework.getSpecificPopValue("frNotWorking");
    }
}
