/* Components -> Vehicle -> VehicleController
 * 
 * DESCRIPTION:
 * Simulates a vehicle using Rigidbody physics. Mass is ignored when forces are applied to the 
 * vehivle (ForceMode = Force, not Acceleration).
 * 
 * FORCES:
 * 1. Gravity
 *    Applied as a constant on each physics update. The direction of the gravity is the normalized
 *    difference from the vehicle center to the closest point on the current floor collider.
 * 2. Spring-based suspension:
 *    Calculated by finding the compression ratio of the spring and scaling it, then applying it in
 *    the opposite direction.
 * 3. Steering forces:
 */

using UnityEngine;
using Utilities;

namespace Vehicle
{
    public class VehicleController : MonoBehaviour
    {
        [SerializeField] private VehiclePhysicsSettings physicsSettings;
        [SerializeField] private Rigidbody rb;

        [Header("Springs")]
        [SerializeField] private Transform frontRight;
        [SerializeField] private Transform frontLeft;
        [SerializeField] private Transform backRight;
        [SerializeField] private Transform backLeft;

        private Ray frontRightRay;
        private Ray frontLeftRay;
        private Ray backRightRay;
        private Ray backLeftRay;

        private Ray[] springRays
        {
            get { return new Ray[] { frontRightRay, frontLeftRay, backRightRay, backLeftRay }; }
        }

        private bool isInitialized
        {
            get
            {
                return !(physicsSettings == null || rb == null ||
                    frontRight == null || frontLeft == null ||
                    backRight == null || backLeft == null);
            }
        }

        private void FixedUpdate()
        {
            if (!isInitialized) return;

            InitSprings();
            foreach (var ray in springRays)
            {
                SimulateSpring(ray);
            }
        }

        private void InitSprings()
        {
            var springDir = -transform.up * physicsSettings.springLength;
            frontRightRay = new(frontRight.position, springDir);
            frontLeftRay = new(frontLeft.position, springDir);
            backRightRay = new(backRight.position, springDir);
            backLeftRay = new(backLeft.position, springDir);
        }

        private void SimulateSpring(Ray springRay)
        {
            RaycastHit hit;
            var layerMask = physicsSettings.springLayerMask;
            var expectedSpringLength = physicsSettings.springLength;

            if (Physics.Raycast(springRay, out hit, expectedSpringLength, layerMask))
            {
                var actualSpringLength = hit.distance;
                var compressionRatio = 1 - (actualSpringLength / expectedSpringLength);
                var forcePoint = springRay.origin;
                var forceDir = -springRay.direction.normalized; // Replace with hit.normal?

                var springForce = forceDir * compressionRatio * physicsSettings.springCompressionForce;
                var dampingForce = Vector3.up * rb.GetPointVelocity(forcePoint).y * physicsSettings.springDamping;
                var netForce = springForce - dampingForce;

                rb.AddForceAtPosition(netForce, forcePoint, ForceMode.Force);
                // rb.AddForceAtPosition(force, forcePoint, ForceMode.VelocityChange);
                Debug.Log("Force = " + netForce);
                // Labels.AtWorld("Force = " + force, forcePoint);
                // Debug.Log("VehicleController.SimulateSpring(): Compression ratio = " + compressionRatio);
            }
        }

        public void OnDrawGizmos()
        {
            if (!isInitialized) return;

            void DrawSpring(Ray springRay)
            {
                float rayLength = physicsSettings.springLength;
                float sphereRadius = 0.05f;

                Gizmos.color = Color.yellow;
                Gizmo.Arrow(springRay.origin, springRay.direction.normalized * rayLength);
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(springRay.origin, sphereRadius);
            }

            InitSprings();
            foreach (var ray in springRays)
            {
                DrawSpring(ray);
            }
            Gizmos.color = Color.cyan;
            Gizmo.Arrow(transform.position, transform.forward * 2);

            Labels.AtWorld("Velocity: " + rb.velocity, transform.position + transform.up * 0.5f);
        }
    }
}