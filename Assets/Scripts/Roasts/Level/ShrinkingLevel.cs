using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roasts.Level
{


    public class ShrinkingLevel : Level
    {

        AnimationCurve w;

        public float shrinkingSpeed;

        float speedDecreasePercentage;

        float DPS;

        public Vector3 scaleIn = new Vector3(1, 0, 1);


        public void Start()
        {
            StartCoroutine(LevelReduction());   

        }

        private void Update()
        {
            // w.Evaluate(dominio) = imagen

       
        }

        IEnumerator LevelReduction()
            {

            for(int i = 0; transform.localScale.x >= 0.5; i++)
            {
                transform.localScale = scaleIn - new Vector3(shrinkingSpeed, 0, shrinkingSpeed) * Time.deltaTime;
            }

        
            yield return null;

        }


    }
}
