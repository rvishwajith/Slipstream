/* Components -> Vehicle -> VehicleController
 * 
 * Class Description:
 * Simulates a vehicle using spring physics.
 */

using UnityEngine;

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
            SimulateSprings();
        }

        private void InitSprings()
        {
            var dir = -transform.up * physicsSettings.springLength;
            frontRightRay = new(frontRight.position, dir);
            frontLeftRay = new(frontLeft.position, dir);
            backRightRay = new(backRight.position, dir);
            backLeftRay = new(backLeft.position, dir);
        }

        private void SimulateSprings()
        {
            var layerMask = physicsSettings.springLayerMask;
            var castDist = physicsSettings.springLength;
            RaycastHit hit;

            if (Physics.Raycast(frontRightRay, out hit, castDist, layerMask))
            {

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
                Gizmos.DrawRay(springRay.origin, springRay.direction.normalized * rayLength);
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(springRay.origin, sphereRadius);
            }

            InitSprings();
            DrawSpring(frontRightRay);
            DrawSpring(frontLeftRay);
            DrawSpring(backRightRay);
            DrawSpring(backLeftRay);
        }
    }
}