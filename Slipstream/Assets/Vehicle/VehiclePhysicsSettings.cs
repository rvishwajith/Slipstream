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
        [Header("Rigidbody")]
        [SerializeField][Range(1, 100)] public float mass = 1;
        [SerializeField][Range(0, 20)] public float drag = 0;

        [Header("Springs")]
        [SerializeField][Range(0.1f, 5)] public float springLength = 0.5f;
        [SerializeField] public LayerMask springLayerMask;
    }
}