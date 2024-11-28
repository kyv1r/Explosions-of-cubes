using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Fuse : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public void ExplodeCubes(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            Rigidbody rigidbody = cube.Rigidbody;
                rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            
        }
    }
}
