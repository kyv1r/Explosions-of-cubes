using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Recolorer : MonoBehaviour
{
    public void PaintCubes(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
            cube.Renderer.material.color = GetRandomColor();
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
