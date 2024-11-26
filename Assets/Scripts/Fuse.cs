using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuse : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private Spawn _spawn;

    public event Action IsDestroyed;

    private void OnMouseUpAsButton()
    {
        IsDestroyed?.Invoke();
        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObjects in GetExplodableObjects())
            explodableObjects.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        List<Collider> hits = _spawn.GetCollidersObjects();

        List<Rigidbody> cubes = new();

        if (hits == null)
        {
            return null;
        }

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);
        }

        return cubes;
    }
}
