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
        }

        IEnumerator LevelReduction()
        {
            // for (float shrinkingSpeed = 1f; transform.localScale.x >= PorcentajeFinal*0.01+0.001; shrinkingSpeed -= 0.001f)
            /* for (float shrinkingSpeed = 1f; transform.localScale.x >= PorcentajeFinal * 0.01 + 0.001; shrinkingSpeed -= 0.001f)
             {

                 scaleIn = transform.localScale;
                 gameObject.transform.localScale = new Vector3(shrinkingCurve.Evaluate(shrinkingSpeed), 0, shrinkingCurve.Evaluate(shrinkingSpeed));
                 //gameObject.transform.localScale = scaleIn * shrinkingSpeed.Evaluate(3f);

                 yield return null;
                 // yield return new WaitForSeconds(1);
             }
             */
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
