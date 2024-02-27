using System;

namespace Sadalmelik.FitApp.Main
{
    [Serializable]
    public class ModelWHO : ICaloriesModel
    {
        public float CoefScale;
        
        public float CoefBiasA;
        public float CoefBiasB;
        public float CoefBiasC;
        
        public float CoefWeightA;
        public float CoefWeightB;
        public float CoefWeightC;
        
        public float Calculate(UserData userData)
        {
            switch (userData.Age)
            {
                case float and < 30:
                    return CoefScale * (CoefBiasA + CoefWeightA * userData.weight);
                case float and >= 30 and < 64:
                    return CoefScale * (CoefBiasB + CoefWeightB * userData.weight);
                default:
                    return CoefScale * (CoefBiasC + CoefWeightC * userData.weight);
            }
        }
    }
}