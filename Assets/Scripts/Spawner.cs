using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _initalCube;
    [SerializeField] private Recolorer _recolorer;

    private void OnEnable()
    {
        _initalCube.Ñracked += Create;
    }

    private void OnDisable()
    {
        _initalCube.Ñracked -= Create;
    }

    private void Create()
    {
        List<Cube> newCubes = new List<Cube>();

        float minCubeCount = 2;
        float maxCubeCount = 6;
        float currentCountCubes = UnityEngine.Random.Range(minCubeCount, maxCubeCount + 1);

        float coefficientSizeChange = 2;
        _initalCube.transform.localScale /= coefficientSizeChange;

        float currentChance = _initalCube.ChanceDisintegration;
        float coefficientChanceChange = 2;
        currentChance /= coefficientChanceChange;

        for (int i = 0; i < currentCountCubes; i++)
        {
            Cube spawnedCube = Instantiate(_initalCube, _initalCube.transform.localPosition, Quaternion.identity);
            spawnedCube.Initialize(currentChance);
            newCubes.Add(spawnedCube);

        }

        _recolorer.PaintCubes(newCubes);
    }
}
