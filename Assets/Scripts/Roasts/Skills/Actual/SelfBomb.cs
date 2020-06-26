using System;
using Roasts.Skills.Behaviour;
using Roasts.Skills.Data;
using UnityEngine;

namespace Roasts.Skills.Actual
{
    public class SelfBomb : Skill<OthersData>
    {
        private float sqrRadius = 0;

        private void Awake()
        {
            sqrRadius = data.radius * data.radius;
        }

        protected override void OnSkillUse(
            Vector3 aimDirection = new Vector3(),
            Vector3 faceDirection = new Vector3())
        {
            if (owner != LocalPlayer)
            {
                // Calculate direction from skill to player
                var skillToPlayerDir = LocalPlayer.transform.position - transform.position;

                // Check if player is within radius
                if (skillToPlayerDir.sqrMagnitude - sqrRadius <= 0)
                {
                    LocalPlayersRB.AddRelativeForce(skillToPlayerDir * (data.pushingDistance +
                                                                        data.pushingDistance *
                                                                        data.levelIncreaseCurve.Evaluate(
                                                                            (CurrentLevel - 1) * .1f)),
                        ForceMode.Impulse);
                    
                    LocalPlayer.TakeDamage(data.significantAmount);
                }
            }
        }
    }
}