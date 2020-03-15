using System.Collections.Generic;

public class MigrationFramework
{
	private int frPop;
	private int usPop;

    /*
	private List<double> separatedPopValues = {
		neMigrants, mwMigrants, sMigrants, wMigrants, //index 0-3
		usLessThanHighschool, usHighschool, usHighschoolGrad, usTwoYear, usBachelors, usOther, //index 4-9
		frLessThanHighschool, frHighschool, frHighschoolGrad, frTwoYear, frBachelors, frOther, //index 10-15
		usInc, frInc, frLegalInc, frIllegalInc, //16-19
		usUnEm, usNotWorking, frUnEm, frNotWorking //20-23
	};
    */

    Dictionary<string, double> separatedPopValues = new Dictionary<string, double>();

	public MigrationFramework()
	{
		frPop = 44406371;
		usPop = 281312807;
        populateDictionary();
		
		updateSeparatePopValues();
	}

    private void populateDictionary()
    {
        separatedPopValues.Add("neMigrants", 0);
        separatedPopValues.Add("mwMigrants", 0);
        separatedPopValues.Add("sMigrants", 0);
        separatedPopValues.Add("wMigrants", 0);
        separatedPopValues.Add("usLessThanHighschool", 0);
        separatedPopValues.Add("usHighschool", 0);
        separatedPopValues.Add("usHighschoolGrad", 0);
        separatedPopValues.Add("usTwoYear", 0);
        separatedPopValues.Add("usBachelors", 0);
        separatedPopValues.Add("usOther", 0);
        separatedPopValues.Add("frLessThanHighschool", 0);
        separatedPopValues.Add("frHighschool", 0);
        separatedPopValues.Add("frHighschoolGrad", 0);
        separatedPopValues.Add("frTwoYear", 0);
        separatedPopValues.Add("frBachelors", 0);
        separatedPopValues.Add("frOther", 0);
        separatedPopValues.Add("usInc", 0);
        separatedPopValues.Add("frInc", 0);
        separatedPopValues.Add("frLegalInc", 0);
        separatedPopValues.Add("frIllegalInc", 0);
        separatedPopValues.Add("usUnEm", 0);
        separatedPopValues.Add("usNotWorking", 0);
        separatedPopValues.Add("frUnEm", 0);
        separatedPopValues.Add("frNotWorking", 0);
    }
	
	public void updateSeparatePopValues()
	{
        /*
		int usedPop = 0;
		for (int i = 0; i < 23; i++)
		{
			if ((i >= 4 && i < 10) || i == 16 || i == 20 || i == 21)
				usedPop = usPop;
			else
				usedPop = frPop;
			
			separatedPopValues. = values.alterPopValue(usPop, i);
		}
        */
        Dictionary<string, double> newValues = new Dictionary<string, double>();
        foreach(KeyValuePair<string, double> kvp in separatedPopValues)
        {
            if (kvp.Key.Substring(0, 2) == "us")
                newValues.Add(kvp.Key, StaticValues.alterPopValue(usPop, kvp.Key));
            else
                newValues.Add(kvp.Key, StaticValues.alterPopValue(frPop, kvp.Key));
        }
        separatedPopValues = newValues;
	}
	
	public void yearlyPopUpdate()
	{
		usPop += (int)((usPop / 2 * StaticValues.getUsRateIncrease()) + (frPop / 2 * StaticValues.getFrRateIncrease()));
        updateSeparatePopValues();
	}

    public void implementNewPolicy(float usPercentChange, float frPercentChange)
    {
        usPop = (int) (usPop * usPercentChange);
        frPop = (int) (frPop * frPercentChange);
        updateSeparatePopValues();
    }
	
	// Getters
	public double getUsPop() { return usPop; }
	public double getFrPop() { return frPop; }
	public Dictionary<string, double> getAllPopValues() { return separatedPopValues; }
    public double getSpecificPopValue(string dictKey)
    {
        if (separatedPopValues.ContainsKey(dictKey))
            return separatedPopValues[dictKey];
        else
            return -1;
    }
	

	private static class StaticValues
	{
		// Proportions of Migrants per region
		private static float neMigrantsRate = 0.21f; //0
		private static float mwMigrantsRate = 0.11f; //1
		private static float sMigrantsRate = 0.33f; //2
		private static float wMigrantsRate = 0.34f; //3
		
		// Birth rates per year
		private static float frRate = 1.0774f;
		private static float usRate = 1.562f;
		
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
		private static float frIncRate = 0.0066f; //17
		private static float frLegalIncRate = 0.0047f; //18
		private static float frIllegalIncRate = 0.0085f; //19
		
		// Unemployment Rate
		private static float usUnEmRate = 0.054f; //20
		private static float usNotWorkingRate = .375f; //21
		
		private static float frUnEmRate = 0.045f; //22
		private static float frNotWorkingRate = .34f; //23
		
		public static double alterPopValue(int pop, string key)
		{
			switch(key)
			{
				case "neMigrants":
					return pop * neMigrantsRate;
					break;
				case "mwMigrants":
					return pop * mwMigrantsRate;
					break;
				case "sMigrants":
					return pop * sMigrantsRate;
					break;
				case "wMigrants":
					return pop * wMigrantsRate;
					break;
				case "usLessThanHighschool":
					return pop * usLessThanHighschoolRate;
					break;
				case "usHighschool":
					return pop * usHighschoolRate;
					break;
				case "usHighschoolGrad":
					return pop * usHighschoolGradRate;
					break;
				case "usTwoYear":
					return pop * usTwoYearRate;
					break;
				case "usBachelors":
					return pop * usBachelorsRate;
					break;
				case "usOther":
					return pop * usOtherRate;
					break;
				case "frLessThanHighschool":
					return pop * frLessThanHighschoolRate;
					break;
				case "frHighschool":
					return pop * frHighschoolRate;
					break;
				case "frHighschoolGrad":
					return pop * frHighschoolGradRate;
					break;
				case "frTwoYear":
					return pop * frTwoYearRate;
					break;
				case "frBachelors":
					return pop * frBachelorsRate;
					break;
				case "frOther":
					return pop * frOtherRate;
					break;
				case "usInc":
					return pop * usIncRate;
					break;
				case "frInc":
					return pop * frIncRate;
					break;
				case "frLegalInc":
					return pop * frLegalIncRate;
					break;
				case "frIllegalInc":
					return pop * frIllegalIncRate;
					break;
				case "usUnEm":
					return pop * usUnEmRate;
					break;
				case "usNotWorking":
					return pop * usNotWorkingRate;
					break;
				case "frUnEm":
					return pop * frUnEmRate;
					break;
				case "frNotWorking":
					return pop * frNotWorkingRate;
					break;
				default:
					return pop;
					break;
			}
		}
		
        public static float getUsRateIncrease() { return usRate; }
        public static float getFrRateIncrease() { return frRate; }
	}
}
