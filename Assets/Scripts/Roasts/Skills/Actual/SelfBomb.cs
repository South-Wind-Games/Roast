using System;
using Roasts.Skills.Behaviour;
using Roasts.Skills.Data;
using UnityEngine;

namespace Roasts.Skills.Actual
{
    public class SelfBomb : Skill<OthersData>
    {
        [SerializeField] private LayerMask roastPlayer;
        [SerializeField] private RoastPlayer owner;

        private Vector3 enemyPos;
        private Vector3 vectorDirection;
        [SerializeField] private RoastPlayer enemy;
        private Rigidbody rb;

        protected override void OnSkillUse()
        {   
            /*RaycastHit hit;
            if (Physics.SphereCast(owner.transform.position, data.radius, transform.forward , out hit, 0.1, roastPlayer))
            {
                Debug.Log("entre a tu hermana");
                //vectorDirection = (hit.transform.position - Owner.transform.position).normalized;
            }*/
            rb = enemy.GetComponent<Rigidbody>();
            Calculate();
            rb.AddRelativeForce(vectorDirection * (data.pushingDistance + data.pushingDistance *
                                data.levelIncreaseCurve.Evaluate((CurrentLevel - 1) / 10f)), ForceMode.Impulse);
            enemy.TakeDamage(data.significantAmount);

        }
        
        
        void Calculate()
        {
            enemyPos = enemy.transform.position;
            vectorDirection = (enemyPos - Owner.transform.position).normalized;
          
        }
        
        
    }
}