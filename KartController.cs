using JetBrains.Annotations;
//using Unity.VisualScripting;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class KartController : MonoBehaviour
{
    // These values control how quickly the kart accelerates,
    // its maximum speed, and how quickly it turns.
    public float acceleration = 20f;
    public float maxSpeed = 30f;
    public float turnSpeed = 50f;

    private Rigidbody rb; // Stores a reference to the kart's Rigidbody so the script can apply forces and control its physics.

    void Start()
    {
        // Gets the Rigidbody component attached to the kart
        // and stores it in the "rb" variable.
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // These variables store the player's movement inputs.
        // They start at 0, meaning the kart is not moving or steering.
        float forwardInput = 0f;
        float steeringInput = 0f;

        // Checks that a keyboard is connected before reading keyboard input.
        if (Keyboard.current != null)
        {
            // 1f means full forward input.
            // 1f is used instead of 1 because this variable is a float.
            if (Keyboard.current.upArrowKey.isPressed)
                forwardInput = 1f;

            // -1f means full reverse input.
            // The negative value tells the game to apply movement backwards.
            if (Keyboard.current.downArrowKey.isPressed)
                forwardInput = -1f;

            // -1f means steer fully to the left.
            if (Keyboard.current.leftArrowKey.isPressed)
                steeringInput = -1f;

            // 1f means steer fully to the right.
            if (Keyboard.current.rightArrowKey.isPressed)
                steeringInput = 1f;


            Vector3 force =            // Creates a force that pushes the kart forwards or backwards.
                transform.forward *       // transform.forward is the direction the kart is facing.
                forwardInput *            // forwardInput determines whether it moves forward or backwards.
                acceleration;            // acceleration controls how strong the force is.


            // Applies the calculated force to the kart's Rigidbody.
            rb.AddForce(force, ForceMode.Acceleration); // ForceMode.Acceleration makes the force behave like acceleration,
                                                         // rather than directly changing the kart's velocity.



            Vector3 horizontalVelocity =
                new Vector3(
                    rb.linearVelocity.x,  // Creates a new Vector3 containing only the kart's horizontal 
                    0f,                   // movement (X and Z). The Y value is set to 0 so vertical movement,                       
                    rb.linearVelocity.z   // such as jumping or falling, is ignored.  
                );


            // Checks whether the kart's horizontal speed is greater than the maximum speed we allowed.
            if (horizontalVelocity.magnitude > maxSpeed)
            {
                // Normalizes the velocity to get only its direction, then multiplies that direction by maxSpeed.
                // This prevents the kart from going faster than the limit.
                horizontalVelocity =
                    horizontalVelocity.normalized * maxSpeed;

                rb.linearVelocity = new Vector3(    // Applies the limited horizontal velocity back to the Rigidbody.
                    horizontalVelocity.x,
                    rb.linearVelocity.y,                // The Y velocity is kept unchanged so the kart can still jump or fall normally.
                    horizontalVelocity.z                

                );
            }


            // Only allows the kart to turn when it is actually moving.
            // The 0.5f prevents the kart from turning when it is almost stationary.
            if (horizontalVelocity.magnitude > 0.5f)
            {
                float turnAmount =                  // Calculates how much the kart should rotate.
                    steeringInput *                // steeringInput determines left/right direction.
                    turnSpeed *                // turnSpeed controls how quickly it turns.
                    Time.fixedDeltaTime;      // Time.fixedDeltaTime keeps the turning consistent with physics.

                // Rotates the kart around its Y axis.
                // X and Z remain 0 so the kart does not rotate sideways or backwards.
                transform.Rotate(0f, turnAmount, 0f);
            }
        }
    }
}