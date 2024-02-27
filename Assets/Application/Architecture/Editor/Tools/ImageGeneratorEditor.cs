using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Sadalmelik.FitApp.EditorScripts
{
    [CustomEditor(typeof(ImageGenerator))]
    public class ImageGeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var imageGeneratorSettings = (ImageGenerator)target;

            if (GUILayout.Button("Generate", GUILayout.Height(40)))
            {
                GenerateImage(imageGeneratorSettings);
            }
        }

        private static void GenerateImage(ImageGenerator settings)
        {
            int width = settings.size.x;
            int height = settings.size.y;
            
            Texture2D image = new Texture2D(
                width, height,
                TextureFormat.RGBA32,
                false);

            float cx = width * 0.5f;
            float cy = height * 0.5f;
            float midRadius = 0.5f * ( settings.minRadius + settings.maxRadius );
            for (int y=0;y<height;y++)
            for (int x = 0; x < width; x++)
            {
                float dx = x - cx;
                float dy = y - cy;
                float dist = Mathf.Sqrt(dx * dx + dy * dy);

                float value = 0;
                if (dist <= midRadius)
                    value = CalculateValue(dist, settings.minRadius, settings.smooth);
                else
                    value = 1 - CalculateValue(dist, settings.maxRadius, settings.smooth);
                
                image.SetPixel(x, y, new Color(1,1,1,value));
            }
            image.Apply();
            
            byte[] bytes = ImageConversion.EncodeToPNG(image);
            var name = settings.fileName;
            if (!name.EndsWith(".png"))
                name += ".png";
            var filePath = Path.Combine(Application.dataPath, settings.filePath, name);
            File.WriteAllBytes( filePath, bytes);
            Object.DestroyImmediate(image);
            AssetDatabase.Refresh();
        }

        private static float CalculateValue(float x, float dist,  float smooth)
        {
            return Mathf.Clamp01((x - dist) / Mathf.Max(smooth, 0.0001f) + 0.5f);
        }
    }
}