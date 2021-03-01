using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IDJ_enums
{
    public enum EnemyState
    {
        Idle,
        Attacking
    }
}
namespace IDJ_code
{
    public class Enemy : EntityCharacter
    {
        public float rangeTriggerAttackState;
        public LayerMask targetLayerMask;

        IDJ_enums.EnemyState state;

        // Start is called before the first frame update
        public override void Awake()
        {
            base.Awake();
            state = IDJ_enums.EnemyState.Idle;
        }

        void Update()
        {
            if (IsInAttackRange())
            {
                SetAttackingState();
                Attack();
            }
            else
            {
                SetNormalState();
            }

        }

        private void Attack()
        {
            Debug.Log("attacking " + this.transform.name);
            GetComponentInChildren<GunHolder>().OnShoot();

        }

        bool IsInAttackRange()
        {
            bool atck = false;
            var atckDirection = (-transform.position + FindObjectOfType<CharacterController2D>().transform.position).normalized ;

            Debug.DrawRay(transform.position, atckDirection * rangeTriggerAttackState, Color.green);

            var hitInfo = Physics2D.Raycast(transform.position, atckDirection, rangeTriggerAttackState, 1 << LayerMask.NameToLayer("Player")); //targetLayerMask
            // test layer

            if (Vector2.Distance(hitInfo.point, transform.position) <= rangeTriggerAttackState)
            {
                Debug.Log(hitInfo.distance);
                atck = true;
            }

            return atck;
        }
        void SetNormalState()
        {
            this.state = IDJ_enums.EnemyState.Idle;
        }
        void SetAttackingState()
        {
            this.state = IDJ_enums.EnemyState.Attacking;
        }

    }
}

