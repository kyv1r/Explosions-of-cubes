using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Spawner : MonoBehaviour
{
    private static float s_maxChance = 200;

    [SerializeField] private Cube _initialCube;

    public event Action Created;

    protected List<Rigidbody> _newCubes;

    private Renderer _cubeRenderer;

    private void OnEnable()
    {
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

        _newCubes = new List<Rigidbody>();

        if (TryCreate())
        {
            Cube newCube = _initialCube;
            newCube.transform.localScale /= 2;
            _cubeRenderer = newCube.CubeRenderer;

            for (int i = 0; i < currentCubes; i++)
            {
                _cubeRenderer.material = new Material(_cubeRenderer.material);
                _cubeRenderer.material.color = GetRandomColor();
                Instantiate(newCube);
                _newCubes.Add(newCube.CubeRigidbody);
            }

            Created?.Invoke();
        }
    }

    private bool TryCreate()
    {
        float lowChance = 0;
        float highChance = 100;
        float chance = UnityEngine.Random.Range(lowChance, highChance);

        if (chance > s_maxChance)
        {
            Debug.Log($"Выпало {chance} из {s_maxChance}: Неповезло");
            return false;
        }
        else
        {
            s_maxChance /= 2;
            Debug.Log($"Выпало {chance} из {s_maxChance}: Повезло");
            return true;
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
