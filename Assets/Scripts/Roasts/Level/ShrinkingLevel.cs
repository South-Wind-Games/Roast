using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roasts.Level
{


    public class ShrinkingLevel : Level
    {
        

        [SerializeField]
        private AnimationCurve shrinkingCurve;

        [SerializeField]
        private float totalShrinkTime;

        [SerializeField]
        Vector2 scaleFromTo = new Vector2(1, .1f);

        [SerializeField]
        Vector3 scaleAxis = new Vector3(1, 0, 1);

        void Start()
        {
            //ff
            //curve = new AnimationCurve(new Keyframe(1, 0), new Keyframe(1, 5));
            shrinkingCurve.preWrapMode = WrapMode.Default;
            shrinkingCurve.postWrapMode = WrapMode.Default;

            StartCoroutine(LevelReduction());

            roundTime = 2f;
        }

        IEnumerator LevelReduction()
        {
           
            float timeEllapsed = 0, ratio = 0 ;

            gameObject.transform.localScale = scaleAxis * scaleFromTo.x;

            do
            {
                
                timeEllapsed += Time.deltaTime;

                float curveEvaluate = shrinkingCurve.Evaluate(ratio = timeEllapsed / totalShrinkTime);

                gameObject.transform.localScale = scaleAxis * (scaleFromTo.x + curveEvaluate * (scaleFromTo.y - scaleFromTo.x));

                yield return null;
            }
            while (ratio < 1);

            gameObject.transform.localScale = scaleAxis * scaleFromTo.y;





        }

    }
}
