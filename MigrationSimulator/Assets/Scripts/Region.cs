using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class Region
    {

        int time = 0;   //indicates how many years have gone by in the region so far
        //Input Parameters
        //Utility Function
        float TPR;  //Time Preference Rate
        float IES;  //Intertemporal elasticity of substitution
        float BM;   //Bequest motive

        //Production function
        float TP;   //Technology progress
        float CSIP; //Capital share in production
        float PCD;  //Physical capital depreciation 

        //Tax policy parameters
        float WT;   //Wage tax
        float CT;   //Capital Tax
        float ConT; //Consumption Tax
        float IT;   //Inheritance tax

        //Pension policy parameters
        int CoP;    //Coverage of pension 0=low, 1=high
        float NSP;  //National subsidy to pension
        float RR;   //Replacement ratio

        //Other parameter
        int Q;  //Age of retirement
        int Z;  //Average life expectancy

        //Output Parameters
        //National income (% of GDP)
        float PC;   //Private Consumption
        float GPG;  //Government purchases of goods and services
        float CA;   //Current Account
        float NNS;  //Net National Savings

        //Government Indicators
        float PPW;  //Pension premium to wage
        float GPD;  //Gross public debt
        float PB;   //Primary balance
        float TR;   //Tax revenues
            //Wage Tax, capital tax and consumptional tax are present in inputs as well

        //Other Indicators
        float COR;  //Capital output ratio
        float IR;   //Interest Rate

        float[,] Population = new float[100, 100];   //population for N t,j the size of total population of age j in the period t
        float[,] migration = new float[100, 100];   //net migration for Mt,j denotes the migration in j age-cohort at the time t

        float fertilityRate = 2.46f;    //temporary as we have an issue getting the values from research paper

        //Demographic Projection
        public void updateDemographics()
        {
            //figure out how to do it recursively
        }
        //HouseHoldBehavior
        public void updateHouseHolds()
        {

        }
        //FirmBehavior
        public void updateFirms()
        {

        }
    }
}
