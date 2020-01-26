using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class Region
    {
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
        float AOR;  //Age of retirement
        float ALE;  //Average life expectancy

        
    }
}
