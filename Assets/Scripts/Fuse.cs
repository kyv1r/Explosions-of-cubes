using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuse : MonoBehaviour
{
    [SerializeField] private float _explosionRadius; 
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _explosionEffect;

    public event Action IsDestroyed;

    private void OnMouseUpAsButton()
    {
        Explode();
        Instantiate(_explosionEffect, transform.position, transform.rotation);
        IsDestroyed?.Invoke();
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObjects in GetExplodableObjects())
            explodableObjects.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);
        }

        return cubes;
    }
}
