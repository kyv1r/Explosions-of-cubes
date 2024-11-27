using System.Collections.Generic;
using UnityEngine;

public class Fuse : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private List<Rigidbody> _newCubes;

    public void Initialize(List<Rigidbody> newCubes)
    {
        _newCubes = newCubes;
    }

    public void Explode()
    {
        foreach (Rigidbody cube in _newCubes)
            cube.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);

        _newCubes.Clear();
    }
}
