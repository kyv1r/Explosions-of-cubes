using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _initialCube;
    [SerializeField] private Fuse _fuse;

    public event Action Created;

    private void OnEnable()
    {
        _initialCube.Initialize(100);
        _initialCube.Clicked += Create;
    }

    private void OnDisable()
    {
        _initialCube.Clicked -= Create;
    }

    public void Create()
    {
        float minCubeCount = 2;
        float maxCubeCount = 6;
        float currentCubes = UnityEngine.Random.Range(minCubeCount, maxCubeCount + 1);

        List<Rigidbody> _newCubes = new List<Rigidbody>();

        if (_initialCube.TryCreate(out Cube newCube))
        {
            newCube.transform.localScale /= 2;
            Renderer _cubeRenderer = newCube.Renderer;

            for (int i = 0; i < currentCubes; i++)
            {
                Cube spawnedCube = Instantiate(newCube, transform.position, Quaternion.identity);

                float newChance = newCube.Chance / 2;
                spawnedCube.Initialize(newChance);

                Renderer cubeRenderer = spawnedCube.Renderer;
                cubeRenderer.material = new Material(cubeRenderer.material);
                cubeRenderer.material.color = GetRandomColor();

                _newCubes.Add(spawnedCube.Rigidbody);
            }

            Created?.Invoke();
            _fuse.Initialize(_newCubes);
        }
    }

    private Color GetRandomColor()
    {
        return new Color(
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f)
        );
    }
}
