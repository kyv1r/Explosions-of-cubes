using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _initalCube;
    [SerializeField] private Recolorer _recolorer;

    private List<Cube> _newCubes = new List<Cube>();

    private void OnEnable()
    {
        _initalCube.Ñracked += Create;
    }

    private void OnDisable()
    {
        _initalCube.Ñracked -= Create;

        foreach (var cube in _newCubes)
            cube.Ñracked -= Create;
    }

    private void Create(Cube initalCube)
    {
        List<Cube> newCubes = new List<Cube>();

        float minCubeCount = 2;
        float maxCubeCount = 6;
        float currentCountCubes = UnityEngine.Random.Range(minCubeCount, maxCubeCount + 1);

        float coefficientSizeChange = 2;
        initalCube.transform.localScale /= coefficientSizeChange;

        float currentChance = initalCube.ChanceDisintegration;
        float coefficientChanceChange = 2;
        currentChance /= coefficientChanceChange;

        for (int i = 0; i < currentCountCubes; i++)
        {
            Cube spawnedCube = Instantiate(initalCube, initalCube.transform.localPosition, Quaternion.identity);
            spawnedCube.Initialize(currentChance);
            spawnedCube.Ñracked += Create;
            newCubes.Add(spawnedCube);
        }

        _newCubes.AddRange(newCubes);
        _recolorer.PaintCubes(newCubes);
    }
}