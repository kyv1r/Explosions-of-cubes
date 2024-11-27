using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Cube : MonoBehaviour
{
    public event Action Clicked;

    public Rigidbody CubeRigidbody { get; private set; }
    public Renderer CubeRenderer { get; private set; }

    private void Awake()
    {
        CubeRigidbody = GetComponent<Rigidbody>();
        CubeRenderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        Clicked?.Invoke();
        Destroy(gameObject);
    }
}
