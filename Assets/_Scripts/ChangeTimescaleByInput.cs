using UnityEngine;

namespace IDJ_code
{
    [RequireComponent(typeof(CharacterController2D))]
    public class ChangeTimescaleByInput : MonoBehaviour
    {

        [SerializeField]
        public float slowdownFactor = 0.05f;
        [SerializeField]
        public float slowdownLength = 2f;

        private CharacterController2D characterController;

        private void Start()
        {
            characterController = GetComponent<CharacterController2D>();
        }

        public void DoSlowMotion()
        {
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }

        // Update is called once per frame
        void Update()
        {
            if (/*!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.Space) ||*/
                Input.GetAxisRaw(characterController.moveAxis) != 0 /*||!Input.GetKey(KeyCode.S)*/)
            {
                Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;

            }
            else
            {
                DoSlowMotion();

            }
                
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            //Debug.Log(Time.timeScale);
        }
    }
}
