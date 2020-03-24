using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour {
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        public Transform goose;
        public Transform kid;
        public int lag;

        // Use this for initialization
        private void Start() {
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
            //goose = GameObject.FindGameObjectWithTag("goose").GetComponent<Transform>();
            //kid = GameObject.FindGameObjectWithTag("kid").GetComponent<Transform>();
        }

        private void Update() {
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget) {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            } else {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;

            m_LastTargetPosition = target.position;

            //change lag to work for non-constant framerates

            //if (lag == 0)
            //{
            //    if (Input.GetKeyDown(KeyCode.LeftShift))
            //    {
            //        toggle();
            //        lag = 6;
            //    }
            //}
            //else
            //{
            //    lag -= 1;
            //}

        }

        //public void toggle()
        //{
        //    if (target == goose)
        //    {
        //        target = kid;
        //    } else
        //    {
        //        target = goose;
        //    }
        //}

    }

}
