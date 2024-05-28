using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }


        private void Update()
        {
            Vector3 dir = Vector3.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.z = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.z = -1;
            }

            dir.Normalize();

            GetComponent<Rigidbody>().velocity = speed * dir;
        }
    }
}
