using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Controller.Cam.Transitions
{
    using Transition = IEnumerator;
    
    public static class CreateFadeTransition
    {
        public static Transition FadeScreenTransition(this CameraController controller,
            float fadeTime, bool fadeOut = true)
        {
            var fadeObject = CreateFadeObject(controller);
            var texture = fadeObject.GetComponent<RawImage>().texture as Texture2D;

            float time = 0;
            while (true)
            {
                time += Time.deltaTime;
                texture.SetPixel(0, 0, new Color(0, 0, 0, time / fadeTime));
                texture.Apply();
                if (time >= fadeTime) break;
                yield return null;
            }

            while (fadeOut)
            {
                time -= Time.deltaTime;
                texture.SetPixel(0, 0, new Color(0, 0, 0, time / fadeTime));
                texture.Apply();
                if (time < 0) break;
                yield return null;
            }

            GameObject.Destroy(fadeObject);
        }
        private static GameObject CreateFadeObject(CameraController controller)
        {
            var currentTransform = controller.transform;

            var fader = new GameObject();
            fader.transform.position = currentTransform.position + Vector3.forward;
            fader.transform.parent = currentTransform;

            var img = fader.AddComponent<RawImage>();
            var canvas = fader.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceCamera;

            var texture = new Texture2D(1, 1);

            var rectTransform = img.rectTransform;
            texture.SetPixel(0, 0, new Color(0, 0, 0, 0));
            texture.Apply();
            img.texture = texture;
            img.color = Color.black;
            rectTransform.anchorMin = new Vector2(1, 0);
            rectTransform.anchorMax = new Vector2(0, 1);

            return fader;
        }


    }
}