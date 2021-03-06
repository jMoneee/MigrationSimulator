using System.Collections.Generic;
using UnityEngine;

public static class MigrationFramework
{
	private static long frPop = 44406371;
    private static long usPop = 281312807;

    private static Dictionary<string, long> separatedPopValues = new Dictionary<string, long>
    {
        { "neMigrants", 9325338 },
        { "mwMigrants", 4884701 },
        { "sMigrants", 14654103 },
        { "wMigrants", 15098167 },
        { "usLessThanHighschool", 7032821 },
        { "usHighschool", 17722707 },
        { "usHighschoolGrad", 78767586 },
        { "usTwoYear", 87488283 },
        { "usBachelors", 56543875 },
        { "usOther", 33787537 },
        { "frLessThanHighschool", 7726709 },
        { "frHighschool", 4440638 },
        { "frHighschoolGrad", 10802647 },
        { "frTwoYear", 8348398 },
        { "frBachelors", 7904335 },
        { "frOther", 5906048 },
        { "usInc", 4304086 },
        { "frInc", 293083 },
        { "frLegalInc", 208710 },
        { "frIllegalInc", 377545 },
        { "usUnEm", 15190892 },
        { "usNotWorking", 105492303 },
        { "frUnEm", 1998287 },
        { "frNotWorking", 15098167 }
    };
	
	private static void updateSeparatePopValues()
	{
        Dictionary<string, long> newValues = new Dictionary<string, long>();
        foreach(KeyValuePair<string, long> kvp in separatedPopValues)
        {
            if (kvp.Key.Substring(0, 2) == "us")
                newValues.Add(kvp.Key, StaticValues.alterPopValue(usPop, kvp.Key));
            else
                newValues.Add(kvp.Key, StaticValues.alterPopValue(frPop, kvp.Key));
        }
        separatedPopValues = newValues;
	}
	
	public static void yearlyPopUpdate()
	{
        Debug.Log("US Pop Begin" + usPop);
        long usPopGrowth = (long)(((usPop / 2) * StaticValues.getUsRateIncrease()) + ((frPop / 2) * StaticValues.getFrRateIncrease()));
        Debug.Log("usPopGrowth " + usPopGrowth);
        long frPopGrowth = (long) StaticValues.getMigrantIncrease();
        Debug.Log("frPopGrowth " + frPopGrowth);
        long usPopDec = (long)(usPop * StaticValues.getDeathRate());
        Debug.Log("usPopDec " + usPopDec);
        long frPopDec =  (long)(frPop * StaticValues.getDeathRate());
        Debug.Log("frPopDec " + frPopDec);
        usPop = usPop + usPopGrowth - usPopDec;
        Debug.Log("US Pop "+ usPop);
        frPop = frPop + frPopGrowth - frPopDec;
        Debug.Log("FR Pop " + frPop);
        updateSeparatePopValues();
	}

    public static void policyChange(float[] valueChanges, string[] dicKeys)
    {
        for (int i = 0; i < valueChanges.Length; i++)
            StaticValues.alterStaticValue(valueChanges[i], dicKeys[i]);
        updateSeparatePopValues();
    }

    public static void setMigrantsLevels(int i)
    {
        StaticValues.setMigrantIncrease(i);
    }

    // Getters
    public static long getUsPop() { return usPop; }
	public static long getFrPop() { return frPop; }
	public static Dictionary<string, long> getAllPopValues() { return separatedPopValues; }
    public static long getSpecificPopValue(string dictKey)
    {
        if (separatedPopValues.ContainsKey(dictKey))
            return separatedPopValues[dictKey];
        else
            return -1;
    }
    public static int getMigrants() { return (int)StaticValues.getMigrantIncrease(); }


    private static class StaticValues
	{
		// Proportions of Migrants per region
		private static float neMigrantsRate = 0.21f; //0
		private static float mwMigrantsRate = 0.11f; //1
		private static float sMigrantsRate = 0.33f; //2
		private static float wMigrantsRate = 0.34f; //3
		
		// Birth rates per year
		private static float frBirthRate = 0.0774f;
		private static float usBirthRate = 0.0562f;

        // Death rates per year
        private static float deathRate = 0.008638f;

        // Migration rate per year
        private static int migrationIncrease = 799046;

        // Education levels
        private static float usLessThanHighschoolRate = 0.025f; //4
		private static float usHighschoolRate = 0.063f; //5
		private static float usHighschoolGradRate = 0.28f; //6
 		private static float usTwoYearRate = 0.311f; //7
		private static float usBachelorsRate = 0.201f; //8
		private static float usOtherRate = 0.12f; //9
		
		private static float frLessThanHighschoolRate = 0.174f; //10
		private static float frHighschoolRate = 0.1f; //11
		private static float frHighschoolGradRate = 0.227f; //12
		private static float frTwoYearRate = 0.188f; //13
		private static float frBachelorsRate = 0.178f; //14
		private static float frOtherRate = 0.133f; //15
		
		// Incarceration Rate
		private static float usIncRate = 0.0153f; //16
		private static float frIncRate = 0.0132f; //17
		private static float frLegalIncRate = 0.0047f; //18
		private static float frIllegalIncRate = 0.0085f; //19
		
		// Unemployment Rate
		private static float usUnEmRate = 0.054f; //20
		private static float usNotWorkingRate = .375f; //21
		
		private static float frUnEmRate = 0.045f; //22
		private static float frNotWorkingRate = .34f; //23
		
		public static long alterPopValue(long pop, string key)
		{
			switch(key)
			{
				case "neMigrants":
                    if ((long)(pop * neMigrantsRate) < 0) return 0;
                    else return (long)(pop * neMigrantsRate);
					break;
				case "mwMigrants":
                    if ((long)(pop * mwMigrantsRate) < 0) return 0;
                    else return (long)(pop * mwMigrantsRate);
                    break;
				case "sMigrants":
                    if ((long)(pop * sMigrantsRate) < 0) return 0;
                    else return (long)(pop * sMigrantsRate);
                    break;
				case "wMigrants":
                    if ((long)(pop * wMigrantsRate) < 0) return 0;
                    else return (long)(pop * wMigrantsRate);
                    break;
				case "usLessThanHighschool":
                    if ((long)(pop * usLessThanHighschoolRate) < 0) return 0;
                    else return (long)(pop * usLessThanHighschoolRate);
                    break;
				case "usHighschool":
                    if ((long)(pop * usHighschoolRate) < 0) return 0;
                    else return (long)(pop * usHighschoolRate);
                    break;
				case "usHighschoolGrad":
                    if ((long)(pop * usHighschoolGradRate) < 0) return 0;
                    else return (long)(pop * usHighschoolGradRate);
                    break;
				case "usTwoYear":
                    if ((long)(pop * usTwoYearRate) < 0) return 0;
                    else return (long)(pop * usTwoYearRate);
                    break;
				case "usBachelors":
                    if ((long)(pop * usBachelorsRate) < 0) return 0;
                    else return (long)(pop * usBachelorsRate);
                    break;
				case "usOther":
                    if ((long)(pop * usOtherRate) < 0) return 0;
                    else return (long)(pop * usOtherRate);
                    break;
				case "frLessThanHighschool":
                    if ((long)(pop * frLessThanHighschoolRate) < 0) return 0;
                    else return (long)(pop * frLessThanHighschoolRate);
                    break;
				case "frHighschool":
                    if ((long)(pop * frHighschoolRate) < 0) return 0;
                    else return (long)(pop * frHighschoolRate);
                    break;
				case "frHighschoolGrad":
                    if ((long)(pop * frHighschoolGradRate) < 0) return 0;
                    else return (long)(pop * frHighschoolGradRate);
                    break;
				case "frTwoYear":
                    if ((long)(pop * frTwoYearRate) < 0) return 0;
                    else return (long)(pop * frTwoYearRate);
                    break;
				case "frBachelors":
                    if ((long)(pop * frBachelorsRate) < 0) return 0;
                    else return (long)(pop * frBachelorsRate);
                    break;
				case "frOther":
                    if ((long)(pop * frOtherRate) < 0) return 0;
                    else return (long)(pop * frOtherRate);
                    break;
				case "usInc":
                    if ((long)(pop * usIncRate) < 0) return 0;
                    else return (long)(pop * usIncRate);
                    break;
				case "frInc":
                    if ((long)(pop * frIncRate) < 0) return 0;
                    else return (long)(pop * frIncRate);
                    break;
				case "frLegalInc":
                    if ((long)(pop * frLegalIncRate) < 0) return 0;
                    else return (long)(pop * frLegalIncRate);
                    break;
				case "frIllegalInc":
                    if ((long)(pop * frIllegalIncRate) < 0) return 0;
                    else return (long)(pop * frIllegalIncRate);
                    break;
				case "usUnEm":
                    if ((long)(pop * usUnEmRate) < 0) return 0;
                    else return (long)(pop * usUnEmRate);
                    break;
				case "usNotWorking":
                    if ((long)(pop * usNotWorkingRate) < 0) return 0;
                    else return (long)(pop * usNotWorkingRate);
                    break;
				case "frUnEm":
                    if ((long)(pop * frUnEmRate) < 0) return 0;
                    else return (long)(pop * frUnEmRate);
                    break;
				case "frNotWorking":
                    if ((long)(pop * frNotWorkingRate) < 0) return 0;
                    else return (long)(pop * frNotWorkingRate);
                    break;
				default:
					return pop;
					break;
			}
		}

        public static void alterStaticValue(float alterVal, string key)
        {
            switch (key)
            {
                case "neMigrants":
                    neMigrantsRate += alterVal;
                    break;
                case "mwMigrants":
                    mwMigrantsRate += alterVal;
                    break;
                case "sMigrants":
                    sMigrantsRate += alterVal;
                    break;
                case "wMigrants":
                    wMigrantsRate += alterVal;
                    break;
                case "usLessThanHighschool":
                    usLessThanHighschoolRate += alterVal;
                    break;
                case "usHighschool":
                    usHighschoolRate += alterVal;
                    break;
                case "usHighschoolGrad":
                    usHighschoolGradRate += alterVal;
                    break;
                case "usTwoYear":
                    usTwoYearRate += alterVal;
                    break;
                case "usBachelors":
                    usBachelorsRate += alterVal;
                    break;
                case "usOther":
                    usOtherRate += alterVal;
                    break;
                case "frLessThanHighschool":
                    frLessThanHighschoolRate += alterVal;
                    break;
                case "frHighschool":
                    frHighschoolRate += alterVal;
                    break;
                case "frHighschoolGrad":
                    frHighschoolGradRate += alterVal;
                    break;
                case "frTwoYear":
                    frTwoYearRate += alterVal;
                    break;
                case "frBachelors":
                    frBachelorsRate += alterVal;
                    break;
                case "frOther":
                    frOtherRate += alterVal;
                    break;
                case "usInc":
                    usIncRate += alterVal;
                    break;
                case "frInc":
                    frIncRate += alterVal;
                    break;
                case "frLegalInc":
                    frLegalIncRate += alterVal;
                    break;
                case "frIllegalInc":
                    frIllegalIncRate += alterVal;
                    break;
                case "usUnEm":
                    usUnEmRate += alterVal;
                    break;
                case "usNotWorking":
                    usNotWorkingRate += alterVal;
                    break;
                case "frUnEm":
                    frUnEmRate += alterVal;
                    break;
                case "frNotWorking":
                    frNotWorkingRate += alterVal;
                    break;
            }
        }

        // Getters
        public static float getUsRateIncrease() { return usBirthRate; }
        public static float getFrRateIncrease() { return frBirthRate; }
        public static float getDeathRate() { return deathRate; }
        public static float getMigrantIncrease() { return migrationIncrease; }

        // Setters
        public static void setMigrantIncrease(int x) { migrationIncrease = x; }
	}
}
