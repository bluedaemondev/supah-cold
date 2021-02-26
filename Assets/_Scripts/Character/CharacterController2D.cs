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
    public class CharacterController2D : MonoBehaviour
    {
        public string moveAxis = "Horizontal";
        [SerializeField]
        float moveSpeed = 10f;
        [SerializeField]
        float rollSpeed = 12f;

        //bool isDashButtonDown;
        Rigidbody2D rbCharacter;

        Vector2 moveDir;
        Vector2 rollDir;
        Vector3 lastMoveDir;

        IDJ_enums.CharacterState state;


        // Start is called before the first frame update
        void Awake()
        {
            rbCharacter = GetComponent<Rigidbody2D>();
            state = IDJ_enums.CharacterState.Normal;
        }

        // Update is called once per frame
        void Update()
        {
            switch (state)
            {
                case IDJ_enums.CharacterState.Normal:
                    if (Input.GetAxisRaw(moveAxis) != 0)
                    {
                        moveDir.x = Input.GetAxisRaw(moveAxis);
                    }
                    else
                    {
                        moveDir.x = 0f;
                    }

                    moveDir = moveDir.normalized;
                    
                    if(moveDir.x != 0)
                    {
                        lastMoveDir = moveDir;
                    }

                    // characterBase.PlayMoveAnim(moveDir);

                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        rollDir = lastMoveDir;
                        rollSpeed = 250f/5;
                        state = IDJ_enums.CharacterState.Rolling;
                        //characterBase.PlayRollAnimation(rollDir);
                    }

                    break;
                case IDJ_enums.CharacterState.Rolling:
                    float rollSpeedDropMultiplier = 5f;
                    rollSpeed -= rollSpeed * rollSpeedDropMultiplier * Time.deltaTime;

                    float rollSpeedMinimum = 12f;
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
                    rbCharacter.velocity = moveDir * moveSpeed;

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
    }
}
