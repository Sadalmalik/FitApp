using Sadalmelik.FitApp.Architecture;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sadalmelik.FitApp.Main
{
    [CreateAssetMenu(
        menuName = "[FitApp]/ApplicationConfig",
        fileName = "ApplicationConfig",
        order = 0)]
    public class ApplicationConfig : SingletonScriptableObject<ApplicationConfig>
    {
        [Header("Base")]
        [TextArea(3, 8)]
        public string DatabaseSource = "https://docs.google.com/spreadsheets/d/e/2PACX-1vSYvJ_7Z5-yiv7aM0H30T91bUqj5C8t7eJ65DsU1B5hfRscRIsr1NAkPZVo1poglbkSa_R6qMfUocWn/pub?gid=0&single=true&output=csv";
        
        [Header("Models")]
        [FormerlySerializedAs("HarrisBenedictModelMale")]
        public ModelGeneral harrisBenedictMale = new ModelGeneral
        {
            Bias = 88.362f,
            CoefWeight = 13.397f,
            CoefHeight = 4.799f,
            CoefAge = -5.677f
        };
        [FormerlySerializedAs("HarrisBenedictModelFemale")]
        public ModelGeneral harrisBenedictFemale = new ModelGeneral
        {
            Bias = 447.593f,
            CoefWeight = 9.247f,
            CoefHeight = 3.098f,
            CoefAge = -4.330f
        };
        [FormerlySerializedAs("MifflinStJeorModelMale")]
        public ModelGeneral mifflinStJeorMale = new ModelGeneral
        {
            Bias = 5,
            CoefWeight = 10f,
            CoefHeight = 6.25f,
            CoefAge = -5f
        };
        [FormerlySerializedAs("MifflinStJeorModelFemale")]
        public ModelGeneral mifflinStJeorFemale = new ModelGeneral
        {
            Bias = -161,
            CoefWeight = 10f,
            CoefHeight = 6.25f,
            CoefAge = -5f
        };

        [FormerlySerializedAs("WHOModelMale")]
        public ModelWHO modelWhoMale = new ModelWHO
        {
            CoefScale = 240,
            CoefBiasA = 2.896f,
            CoefBiasB = 3.653f,
            CoefBiasC = 2.459f,
            CoefWeightA = 0.063f,
            CoefWeightB = 0.048f,
            CoefWeightC = 0.049f
        };

        [FormerlySerializedAs("WHOModelFemale")]
        public ModelWHO modelWhoFemale = new ModelWHO
        {
            CoefScale = 240,
            CoefBiasA = 2.036f,
            CoefBiasB = 3.538f,
            CoefBiasC = 2.755f,
            CoefWeightA = 0.062f,
            CoefWeightB = 0.034f,
            CoefWeightC = 0.038f
        };
    }
}