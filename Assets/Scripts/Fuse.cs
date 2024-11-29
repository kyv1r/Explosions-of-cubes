using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Fuse : MonoBehaviour
{
    [SerializeField] private float _defoaltExplosionForce = 200;
    [SerializeField] private float _defoaltExplosionRadius = 20;

    public void ExplodeCubes(Cube currentCube)
    {
        float newExplosionForce = _defoaltExplosionForce * (1 / currentCube.transform.localScale.x);
        float newExplosionRadius = _defoaltExplosionRadius * (1 / currentCube.transform.localScale.x);

        foreach (Rigidbody cube in GetExplodableCubes(currentCube))
            cube.AddExplosionForce(newExplosionForce, transform.position, newExplosionRadius);
    }

    private List<Rigidbody> GetExplodableCubes(Cube currentCube)
    {
        Collider[] hits = Physics.OverlapSphere(currentCube.transform.position, _defoaltExplosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);
        }

        return cubes;
    }
}
