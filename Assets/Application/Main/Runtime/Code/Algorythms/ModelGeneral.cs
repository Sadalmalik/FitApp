using System;

namespace Sadalmelik.FitApp.Main
{
    [Serializable]
    public class ModelGeneral : ICaloriesModel
    {
        public float Bias;
        public float CoefWeight;
        public float CoefHeight;
        public float CoefAge;
        
        public float Calculate(UserData userData)
        {
            return userData.activity * ( Bias
                + CoefWeight * userData.weight
                + CoefHeight * userData.height
                + CoefAge * userData.Age );
        }
    }
}