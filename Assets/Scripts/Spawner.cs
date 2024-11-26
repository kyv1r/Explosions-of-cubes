using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _initialCube;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private static float _maxChance = 200;

    private List<Rigidbody> _newCubes;
    private Renderer cubeRenderer;

    private void OnEnable()
    {
        _initialCube.IsClicked += Expload;
    }

    private void OnDisable()
    {
        _initialCube.IsClicked -= Expload;
    }

    private void Expload()
    {
        Create();

        Debug.Log(_newCubes.Count);

        foreach (Rigidbody cube in _newCubes)
        {
            cube.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        _newCubes.Clear();
    }

    public void Create()
    {
        float minCubeCount = 2;
        float maxCubeCount = 6;
        float currentCubes = Random.Range(minCubeCount, maxCubeCount + 1);

        _newCubes = new List<Rigidbody>();

        if (TryCreate())
        {
            Cube newCube = _initialCube;
            newCube.transform.localScale /= 2;
            cubeRenderer = newCube.GetComponent<Renderer>();

            for (int i = 0; i < currentCubes; i++)
            {
                cubeRenderer.material = new Material(cubeRenderer.material);
                cubeRenderer.material.color = GetRandomColor();
                Instantiate(newCube);
                _newCubes.Add(newCube.GetComponent<Rigidbody>());
            }
        }
    }

    private bool TryCreate()
    {
        float lowChance = 0;
        float highChance = 100;
        float chance = Random.Range(lowChance, highChance);

        if (chance < _maxChance)
        {
            _maxChance /= 2;
            Debug.Log($"Выпало {chance} из {_maxChance}: Повезло");
            return true;
        }

        Debug.Log($"Выпало {chance} из {_maxChance}: Неповезло");

        return false;   
    }

    private Color GetRandomColor()
    {
        return new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
    }
}
