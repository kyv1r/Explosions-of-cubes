using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]

public class InputManager : MonoBehaviour
{
    public event Action Clicked;

    private void OnMouseUpAsButton()
    {
        Clicked?.Invoke();
    }
}
