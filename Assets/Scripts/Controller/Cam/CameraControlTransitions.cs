using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Controller.Cam
{
    using Transition = IEnumerator;

    public partial class CameraController
    {

        public Transition IdentityTransition(Func<bool> condition = null)
        {
            condition = condition ?? (() => { return true; });
            while (condition())
            {
                yield return null;
            }
        }

        public Transition FollowTransition(Transform target, Func<bool> condition = null)
        {
            condition = condition ?? (() => { return true; });

            var transformComponent = transform;
            while (condition())
            {
                transformComponent.position = new Vector3(target.position.x, target.position.y, transform.position.z);
                yield return null;
            }
        }

        public Transition FadeScreenTransition(float fadeTime, bool fadeOut = true)
        {

            GameObject fadeObject = CreateFadeObject();
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

            Destroy(fadeObject);
        }

        private GameObject CreateFadeObject()
        {
            var currentTransform = this.transform;

            GameObject fader = new GameObject();
            fader.transform.position = currentTransform.position + Vector3.forward;
            fader.transform.parent = currentTransform;

            RawImage img = fader.AddComponent<RawImage>();
            fader.AddComponent<Canvas>();

            Texture2D texture = new Texture2D(1, 1);

            var rectTransform = img.rectTransform;
            texture.SetPixel(0, 0, new Color(0, 0, 0, 0));
            texture.Apply();
            img.texture = texture;
            img.color = Color.black;
            rectTransform.anchorMin = new Vector2(1, 0);
            rectTransform.anchorMax = new Vector2(0, 1);

            return fader;
        }

        public Transition WaitTransition(float timeout)
        {
            float time = timeout;
            while (true)
            {
                time -= Time.deltaTime;
                if(time <=0) yield break;

                yield return null;
            }
        }

        public Transition SmoothGoToTransition(Vector2 target,float speed)
        {
            var transformComponent = transform;
            while (true)
            {
                var deltaSpeed = speed * Time.deltaTime;
                var position = (Vector2)transform.position;

                if (Vector2.Distance(target,position) < deltaSpeed)
                {
                    transformComponent.position = new Vector3(target.x,target.y, transformComponent.position.z);
                    yield break;
                }
                
                var direction = (target - position).normalized;
                var deltaMovement = direction * deltaSpeed;
                
                transformComponent.position = new Vector3(position.x +deltaMovement.x,
                    position.y + deltaMovement.y,
                    transformComponent.position.z);
                yield return null;
            }   
        }

        public Transition ShakeScreenTransition(float amount,float time,bool autoRevert=false)
        {
            var lastTransition = Vector3.zero;
            var cameraTansform = Camera.transform;
            
            while (true)
            {
                time -= Time.deltaTime;
                
                var position = cameraTansform.position;
                if(autoRevert) position -= lastTransition;
                
                lastTransition = (Vector3) UnityEngine.Random.insideUnitCircle * amount;
                
                position += lastTransition;
                cameraTansform.position = position;
                if (time <= 0) yield break;
                
                yield return null;
            }
        }

        public void Reset()
        {
            TransitionStack = IdentityTransition();
        }


    }
}