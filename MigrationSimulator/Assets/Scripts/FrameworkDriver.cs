using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameworkDriver : MonoBehaviour {

    public Text currentYearText;
    int currentYear = 2017;
    public Text usPopText;
    public Text frPopText;

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
    
    void Start ()
    {
        updateAllData();
        sliderText.text = migrantSlider.value.ToString();
	}

    public void incrementYear()
    {
        MigrationFramework.yearlyPopUpdate();
        currentYear++;
        updateAllData();
    }

    public void educationPolicy(bool up)
    {
        float[] values = { -0.011f, 0.004f, 0.003f, 0.002f, 0.001f, 0.001f, -0.011f, 0.004f, 0.003f, 0.002f, 0.001f, 0.001f };
        if (!up)
            values = Array.ConvertAll(values, f => f * -1);

        string[] keys = { "usLessThanHighschool", "usHighschool", "usHighschoolGrad",
            "usTwoYear", "usBachelors", "usOther", "frLessThanHighschool",
            "frHighschool", "frHighschoolGrad", "frTwoYear", "frBachelors", "frOther" };

        MigrationFramework.policyChange(values, keys);
        updateAllData();
        if (up) edPolicyLevel++;
        else edPolicyLevel--;
        edPolicyText.text = "Level: " + edPolicyLevel;
    }

    public void jobPolicy(bool up)
    {
        float[] values = { -0.004f, -0.004f };
        if (!up)
            values = Array.ConvertAll(values, f => f * -1);

        string[] keys = { "usUnEm", "frUnEm" };

        MigrationFramework.policyChange(values, keys);
        updateAllData();
        if (up) jobPolicyLevel++;
        else jobPolicyLevel--;
        jobPolicyText.text = "Level: " + jobPolicyLevel;
    }

    public void jailPolicy(bool up)
    {
        float[] values = { -0.001f, -0.001f, -0.001f, -0.001f };
        if (!up)
            values = Array.ConvertAll(values, f => f * -1);

        string[] keys = { "usInc", "frInc", "frLegalInc", "frIllegalInc" };

        MigrationFramework.policyChange(values, keys);
        updateAllData();
        if (up) jailPolicyLevel++;
        else jailPolicyLevel--;
        jailPolicyText.text = "Level: " + jailPolicyLevel;
    }

    public void setMigrantsPerYear()
    {
        MigrationFramework.setMigrantsLevels((int)migrantSlider.value);
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
        currentYearText.text = "Current Year: " + currentYear;
        frPopText.text = "Foreign Population: " + MigrationFramework.getFrPop();
        usPopText.text = "Native Population: " + MigrationFramework.getUsPop();

        migrantsText.text = "NE Migrants: " + MigrationFramework.getSpecificPopValue("neMigrants")
            + "\nMW Migrants: " + MigrationFramework.getSpecificPopValue("mwMigrants")
            + "\nSouth Migrants: " + MigrationFramework.getSpecificPopValue("sMigrants")
            + "\nWest Migrants: " + MigrationFramework.getSpecificPopValue("wMigrants");

        usEdText.text = "Below High School: " + MigrationFramework.getSpecificPopValue("usLessThanHighschool")
            + "\nSome High School: " + MigrationFramework.getSpecificPopValue("usHighschool")
            + "\nHigh School Diploma: " + MigrationFramework.getSpecificPopValue("usHighschoolGrad")
            + "\nTwo Year Diploma: " + MigrationFramework.getSpecificPopValue("usTwoYear")
            + "\nBachelors Diploma: " + MigrationFramework.getSpecificPopValue("usBachelors")
            + "\nOther: " + MigrationFramework.getSpecificPopValue("usOther");

        frEdText.text = "Below High School: " + MigrationFramework.getSpecificPopValue("frLessThanHighschool")
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
            + "\nOut of Work Force: " + MigrationFramework.getSpecificPopValue("usUnEm");

        frUnemText.text = "Unemployment Number: " + MigrationFramework.getSpecificPopValue("frUnEm")
            + "\nOut of Work Force: " + MigrationFramework.getSpecificPopValue("frNotWorking");
    }
}
