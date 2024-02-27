using UnityEngine;
using UnityEngine.Serialization;

namespace Sadalmelik.FitApp.EditorScripts
{
    [CreateAssetMenu(
        menuName = "[FitApp]/Editor/ImageGenerator",
        fileName = "ImageGenerator",
        order = 0)]
    public class ImageGenerator : ScriptableObject
    {
        public string filePath = "";
        public string fileName = "circle.png";
        public Vector2Int size = new Vector2Int(512, 512);
        public float minRadius = 230;
        public float maxRadius = 250;
        public float smooth = 5;
    }
}