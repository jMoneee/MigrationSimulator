using System;
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

    public Text edPolicyText;
    int edPolicyLevel = 0;
    public Text jobPolicyText;
    int jobPolicyLevel = 0;
    public Text jailPolicyText;
    int jailPolicyLevel = 0;

    public Slider migrantSlider;
    public Text sliderText;

    // Use this for initialization
    void Start ()
    {
        updateAllData();
        sliderText.text = migrantSlider.value.ToString();
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

    public void educationPolicy(bool up)
    {
        float[] x = { -0.011f, 0.004f, 0.003f, 0.002f, 0.001f, 0.001f, -0.011f, 0.004f, 0.003f, 0.002f, 0.001f, 0.001f };
        if (!up)
            x = Array.ConvertAll(x, f => f * -1);

        string[] y = { "usLessThanHighschoolRate", "usHighschoolRate", "usHighschoolGradRate",
            "usTwoYearRate", "usBachelorsRate", "usOtherRate", "frLessThanHighschoolRate",
            "frHighschoolRate", "frHighschoolGradRate", "frTwoYearRate", "frBachelorsRate", "frOtherRate" };

        List<float> values = new List<float>(x);
        List<string> keys = new List<string>(y);

        MigrationFramework.policyChange(values, keys);
        updateAllData();
        if (up) edPolicyLevel++;
        else edPolicyLevel--;
        edPolicyText.text = "Level: " + edPolicyLevel;
    }

    public void jobPolicy(bool up)
    {
        float[] x = { -0.004f, -0.004f };
        if (!up)
            x = Array.ConvertAll(x, f => f * -1);

        string[] y = { "usUnEmRate", "frUnEmRate" };

        List<float> values = new List<float>(x);
        List<string> keys = new List<string>(y);

        MigrationFramework.policyChange(values, keys);
        updateAllData();
        if (up) jobPolicyLevel++;
        else jobPolicyLevel--;
        jobPolicyText.text = "Level: " + jobPolicyLevel;
    }

    public void jailPolicy(bool up)
    {
        float[] x = { -0.001f, -0.001f, -0.001f, -0.001f };
        if (!up)
            x = Array.ConvertAll(x, f => f * -1);

        string[] y = { "usIncRate", "frIncRate", "frLegalIncRate", "frIllegalIncRate" };

        List<float> values = new List<float>(x);
        List<string> keys = new List<string>(y);

        MigrationFramework.policyChange(values, keys);
        updateAllData();
        if (up) jailPolicyLevel++;
        else jailPolicyLevel--;
        jailPolicyText.text = "Level: " + jailPolicyLevel;
    }

    public void setMigrantsPerYear()
    {
        MigrationFramework.setMigrantsLevels((int)migrantSlider.value);
        updateAllData();
        sliderText.text = migrantSlider.value.ToString();
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
