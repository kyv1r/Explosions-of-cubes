using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]

public class Cube : MonoBehaviour
{
    public Renderer Renderer { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public float Chance { get; private set; }

    public event Action Clicked;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
    }


    public void Initialize(float chance)
    {
        Chance = chance;
    }

    public bool TryCreate(out Cube newCube)
    {
        float lowChance = 0;
        float highChance = 100;
        float chance = UnityEngine.Random.Range(lowChance, highChance);

        if (chance <= Chance)
        {
            newCube = this;
            return true;
        }

        newCube = null;
        return false;
    }

    private void OnMouseDown()
    {
        Clicked?.Invoke();
        Destroy(gameObject);
    }
}
