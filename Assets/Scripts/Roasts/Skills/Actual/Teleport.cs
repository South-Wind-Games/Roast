using System;
using System.Collections;
using Roasts.Skills.Behaviour;
using Roasts.Skills.Data;
using UnityEngine;

namespace Roasts.Skills.Actual
{
    public class Teleport : Skill<SkillData>
    {  
        public Vector3 farthestPosToTp;   // this is the position to jump when the mouse click is out of range
        private bool isInRadius;          // check if the mouse click in range
        public Vector3 posClickedMouse;  // where the mouse is click

        public Vector3 vectorDirection;  // Its use when the position is out of range
        

       protected override void OnSkillUse()
        {   var transform1 = Owner.transform;
          IsinRange();        //Check if the mouse pos is in the range of the tp radius
          Calculate(); // calculate the dir of the vector
            if (isInRadius == true)
            {
                transform1.position = posClickedMouse;     //if its true, just tp to that pos 
                Debug.Log("entro con true");
            }
            else
            {
                farthestPosToTp = vectorDirection * (data.significantAmount + data.significantAmount *
                    data.levelIncreaseCurves[0].Evaluate((CurrentLevel - 1) / 10f));

                transform1.position = transform1.position + farthestPosToTp;


                Debug.Log("entró en false");
            }



        }

       void IsinRange()
       {
           Vector3 distanceBetween = posClickedMouse -Owner.transform.position;
           float sqrposdistanceBetween = distanceBetween.sqrMagnitude;
            
           if (sqrposdistanceBetween > data.significantAmount * data.significantAmount)
           {
               isInRadius = false;
           }
           else
           {
               isInRadius = true;
           }
       }

       void Calculate()
       {
           vectorDirection = (posClickedMouse - Owner.transform.position).normalized;
           Debug.Log(vectorDirection);
       }

    }
}