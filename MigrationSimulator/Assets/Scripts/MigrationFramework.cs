public class MigrationFramework
{
	StaticValues values;
	private int frPop;
	private int usPop;
	
	private List<int> separatedPopValues = {
		neMigrants, mwMigrants, sMigrants, wMigrants, //index 0-3
		usLessThanHighschool, usHighschool, usHighschoolGrad, usTwoYear, usBachelors, usOther, //index 4-9
		frLessThanHighschool, frHighschool, frHighschoolGrad, frTwoYear, frBachelors, frOther, //index 10-15
		usInc, frInc, frLegalInc, frIllegalInc, //16-19
		usUnEm, usNotWorking, frUnEm, frNotWorking //20-23
	};
	
	public MigrationFramework()
	{
		values = new StaticValues();
		
		frPop = 44406371;
		usPop = 281312807;
		
		updateSeparatePopValues;
	}
	
	private void updateSeparatedPopValues()
	{
		int usedPop = 0;
		for (int i = 0; i < 23; i++)
		{
			if ((i >= 4 && i < 10) || i == 16 || i == 20 || i == 21)
				usedPop = usPop;
			else
				usedPop = frPop;
			
			separatedPopValues.indexOf(i) = values.alterPopValue(usPop, separatedPopValues.indexOf(i));
		}
	}
	
	

	private class StaticValues
	{
		// Proportions of Migrants per region
		private float neMigrantsRate = 0.21; //0
		private float mwMigrantsRate = 0.11; //1
		private float sMigrantsRate = 0.33; //2
		private float wMigrantsRate = 0.34; //3
		
		// Birth rates per year
		private float frRate = 77.4; //77.4 per 1000 women
		private float usRate = 56.2 //56.2 per 100 women
		
		// NOTE: I'm still not quite sure how to accurately depict this, since the rates are different.
		//	  	 My thought right now is to consider them as population percentage increases per year, like shown below.
		// private float frRate = 1.0774;
		// private float usRate = 1.562;
		
		// Education levels
		private float usLessThanHighschoolRate = 0.025; //4
		private float usHighschoolRate = 0.063; //5
		private float usHighschoolGradRate = 0.28; //6
 		private float usTwoYearRate = 0.311; //7
		private float usBachelorsRate = 0.201; //8
		private float usOtherRate = 0.12; //9
		
		private float frLessThanHighschoolRate = 0.174; //10
		private float frHighschoolRate = 0.1; //11
		private float frHighschoolGradRate = 0.227; //12
		private float frTwoYearRate = 0.188; //13
		private float frBachelorsRate = 0.178; //14
		private float frOtherRate = 0.133; //15
		
		// Incarceration Rate
		private float usIncRate = 0.0153; //16
		private float frIncRate = 0.0066; //17
		private float frLegalIncRate = 0.0047; //18
		private float frIllegalIncRate = 0.0085; //19
		
		// Unemployment Rate
		private float usUnEmRate = 0.054; //20
		private float usNotWorkingRate = .375; //21
		
		private float frUnEmRate = 0.045; //22
		private float frNotWorkingRate = .34; //23
		
		private int alterPopValue(int pop, int key)
		{
			switch(key)
			{
				case 0:
					return pop * neMigrantsRate;
					break;
				case 1:
					return pop * mwMigrantsRate;
					break;
				case 2:
					return pop * sMigrantsRate;
					break;
				case 3:
					return pop * wMigrantsRate;
					break;
				case 4:
					return pop * usLessThanHighschoolRate;
					break;
				case 5:
					return pop * usHighschoolRate;
					break;
				case 6:
					return pop * usHighschoolGradRate;
					break;
				case 7:
					return pop * usTwoYearRate;
					break;
				case 8:
					return pop * usBachelorsRate;
					break;
				case 9:
					return pop * usOtherRate;
					break;
				case 10:
					return pop * frLessThanHighschoolRate;
					break;
				case 11:
					return pop * frHighschoolRate;
					break;
				case 12:
					return pop * frHighschoolGradRate;
					break;
				case 13:
					return pop * frTwoYearRate;
					break;
				case 14:
					return pop * frBachelorsRate;
					break;
				case 15:
					return pop * frOtherRate;
					break;
				case 16:
					return pop * usIncRate;
					break;
				case 17:
					return pop * frIncRate;
					break;
				case 18:
					return pop * frLegalIncRate;
					break;
				case 19:
					return pop * frIllegalIncRate;
					break;
				case 20:
					return pop * usUnEmRate;
					break;
				case 21:
					return pop * usNotWorkingRate;
					break;
				case 22:
					return pop * frUnEmRate;
					break;
				case 23:
					return pop * frNotWorkingRate;
					break;
				default:
					return pop;
					break;
			}
		}
		
	}
}
