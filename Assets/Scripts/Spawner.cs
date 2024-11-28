using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Spawner : MonoBehaviour
{
    public List<Cube> Create(Cube cube)
    {
        float minCubeCount = 2;
        float maxCubeCount = 6;
        int currentCubes = Random.Range((int)minCubeCount, (int)maxCubeCount + 1);

        List<Cube> newCubes = new List<Cube>();

        float currentChance = cube.Chance;

        cube.transform.localScale /= 2;
        currentChance /= 2;

        for (int i = 0; i < currentCubes; i++)
        {
            Cube spawnedCube = Instantiate(cube, cube.transform.position, Quaternion.identity);
            spawnedCube.Initialize(currentChance);
            newCubes.Add(spawnedCube);
        }

        return newCubes;
    }
}
