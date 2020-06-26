using Roasts.Skills.Behaviour;
using Roasts.Skills.Data;
using UnityEngine;

namespace Roasts.Skills.Actual
{
    public class Teleport : Skill<SkillData>
    {
        public Vector3 farthestPosToTp; // this is the position to jump when the mouse click is out of range
        public Vector3 posClickedMouse; // where the mouse is click

        private float sqrRange = 0;

        private void Awake()
        {
            sqrRange = data.significantAmount * data.significantAmount;
        }

        protected override void OnSkillUse(
            Vector3 aimDirection = new Vector3(),
            Vector3 faceDirection = new Vector3())
        {
            var ownersTransform = owner.transform;

            if (IsInRange())
            {
                ownersTransform.position = posClickedMouse; //if its true, just tp to that pos 
            }
            else
            {
                farthestPosToTp = Calculate() * (data.significantAmount + data.significantAmount *
                    data.levelIncreaseCurve.Evaluate((CurrentLevel - 1) * .1f));

                ownersTransform.position = ownersTransform.position + farthestPosToTp;
            }
        }

        private bool IsInRange()
        {
            Vector3 distanceBetween = posClickedMouse - owner.transform.position;
            return distanceBetween.sqrMagnitude <= sqrRange;
        }

        private Vector3 Calculate() // TODO: Fuck this
        {
            return (posClickedMouse - owner.transform.position).normalized;
        }
    }
}