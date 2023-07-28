/* Vehicle -> VehiclePhysicsSettings
 * 
 * Class Description:
 * Physics data applied to a VehicleController at runtime.
 */

using System;
using UnityEngine;

namespace Vehicle
{
    [CreateAssetMenu]
    public class VehiclePhysicsSettings : ScriptableObject
    {
        [Header("Rigidbody Properties")]
        [SerializeField][Range(1, 100)] public float mass = 1;
        [SerializeField][Range(0, 20)] public float drag = 0;

        [Header("Spring Properties")]
        [SerializeField][Range(0.1f, 2f)] public float springLength = 0.5f;
        [SerializeField] public float springCompressionForce = 1;
        [SerializeField][Range(0f, 20f)] public float springDamping = 5;
        [SerializeField] public LayerMask springLayerMask = ~0;
    }
}