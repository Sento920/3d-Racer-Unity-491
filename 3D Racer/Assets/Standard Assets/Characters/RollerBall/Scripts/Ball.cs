using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float m_MovePower = 5; // The force added to the ball to move it.
        [SerializeField] private bool m_UseTorque = true; // Whether or not to use torque to move the ball.
        [SerializeField] private float m_MaxAngularVelocity = 25; // The maximum velocity the ball can rotate at.
        [SerializeField] private float m_JumpPower = 2; // The force added to the ball when it jumps.
        [SerializeField] private float boost = 100;
        private const float k_GroundRayLength = 1f; // The length of the ray to check if the ball is grounded.
        private Rigidbody m_Rigidbody;
        private int total = 30;
        private int curr;

        private void Start()
        {
            curr = 0;
            m_Rigidbody = GetComponent<Rigidbody>();
            // Set the maximum angular velocity.
            GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
        }

        void Update()
        {
            if(curr > total)
            {
                curr = 0;
                boost++;
            }
            curr++;
        }


        public void Move(Vector3 moveDirection, bool jump)
        {   
            // If using torque to rotate the ball...
            if (m_UseTorque)
            {
                // ... add torque around the axis defined by the move direction.
                if (Input.GetKey(KeyCode.LeftShift) && boost > 0)
                {
                    // Otherwise add force in the move direction.
                    m_Rigidbody.AddForce(moveDirection * (m_MovePower * 2.5f));
                    boost--;
                }
                else
                {
                    m_Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * m_MovePower);
                }
            }
            else
            {
                // Otherwise add force in the move direction.
                m_Rigidbody.AddForce(moveDirection * m_MovePower);
            }

            // If on the ground and jump is pressed...
            if (Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength) && jump)
            {
                // ... add force in upwards.
                m_Rigidbody.AddForce(Vector3.up*m_JumpPower, ForceMode.Impulse);
            }
        }

        //adds boost. Amount is the number to add/subtract to the tank, modifier is the operation used.
        public void Boost(float amount, bool modifier)
        {
            if (modifier)
            {
                this.boost += amount;
            }
            else 
            {
                this.boost -= amount;
            }

            if(this.boost > 100f)
            {
                this.boost = 100f;
            }
        }

    }
}
