using UnityEngine;

public class Fuse : Spawner
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private void OnEnable()
    {
        Created += Expload;
    }

    private void OnDisable()
    {
        Created -= Expload;
    }

    private void Expload()
    {
        foreach (Rigidbody cube in _newCubes)
        {
            cube.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        _newCubes.Clear();
    }
}
