using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IDJ_enums
{
    public enum CharacterState
    {
        Normal,
        Rolling
    }

}

namespace IDJ_code
{
    public class CharacterController2D : EntityCharacter
    {
        public string moveAxis = "Horizontal";

        [SerializeField]
        LayerMask platformsLayermask;
        [SerializeField]
        float moveSpeed = 10f;
        [SerializeField]
        float rollSpeed = 12f;
        [SerializeField]
        float jumpVelocity = 10f;
        float lastYVelocity = 0;

        
        Vector2 moveDir;
        Vector2 rollDir;
        Vector3 lastMoveDir;

        public IDJ_enums.CharacterState state;


        // Start is called before the first frame update
        public override void Awake()
        {
            base.Awake();
            state = IDJ_enums.CharacterState.Normal;
        }

        // Update is called once per frame
        void Update()
        {
            switch (state)
            {
                case IDJ_enums.CharacterState.Normal:
                    moveDir.x = Input.GetAxisRaw(moveAxis);
                    FlipSprite(moveDir.x);

                    lastYVelocity = Mathf.Min(rbCharacter.velocity.y, 8f);

                    moveDir = moveDir.normalized;

                    if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) &&
                        IsGrounded())
                    {
                        moveDir.y = (Vector2.up * jumpVelocity).y;
                        lastYVelocity = Mathf.Min(jumpVelocity, 10f);

                    }

                    if (moveDir.x != 0)
                    {
                        lastMoveDir = moveDir;
                    }

                    // characterBase.PlayMoveAnim(moveDir);

                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        lastMoveDir.y = 0;
                        rollDir = lastMoveDir;
                        rollSpeed = 250f / 5;
                        state = IDJ_enums.CharacterState.Rolling;
                        //characterBase.PlayRollAnimation(rollDir);
                    }

                    break;
                case IDJ_enums.CharacterState.Rolling:
                    float rollSpeedDropMultiplier = 5f;
                    rollSpeed -= Mathf.Min(rollSpeed * rollSpeedDropMultiplier * Time.deltaTime, 250f / 5);

                    float rollSpeedMinimum = 11f;
                    if (rollSpeed < rollSpeedMinimum)
                    {
                        state = IDJ_enums.CharacterState.Normal;
                    }
                    break;
            }


        }

        private void FixedUpdate()
        {
            switch (state)
            {
                case IDJ_enums.CharacterState.Normal:
                    var dirMovF = new Vector2(moveDir.x * moveSpeed, lastYVelocity);
                    //dirMovF.y = Physics2D.gravity.y / 2; // watchout
                    rbCharacter.velocity = dirMovF;


                    #region DASH_Mechanic
                    //if (isDashButtonDown)
                    //{
                    //    float dashAmount = 50f;
                    //    Vector3 dashPosition = transform.position + lastMoveDir * dashAmount;

                    //    RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, lastMoveDir, dashAmount, dashLayerMask);
                    //    if (raycastHit2d.collider != null)
                    //    {
                    //        dashPosition = raycastHit2d.point;
                    //    }

                    //    // Spawn visual effect
                    //    DashEffect.CreateDashEffect(transform.position, lastMoveDir, Vector3.Distance(transform.position, dashPosition));

                    //    rbCharacter.MovePosition(dashPosition);
                    //    isDashButtonDown = false;
                    //}
                    #endregion
                    break;
                case IDJ_enums.CharacterState.Rolling:
                    rbCharacter.velocity = rollDir * rollSpeed;
                    break;
            }
        }
        
        public bool IsGrounded()
        {
            RaycastHit2D hitOutput = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 1f, platformsLayermask);


            return hitOutput.collider != null;
        }

        public override void OnDie()
        {
            GameEventsManager.instance.onDefeat.Invoke();
            base.OnDie();

        }
    }
}
