﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IDJ_code.DebugTools
{
    public class FixedMovement : MonoBehaviour
    {
        public Vector2 direction = Vector2.left;
        

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += (Vector3)(direction * Time.deltaTime);
        }
    }
}
