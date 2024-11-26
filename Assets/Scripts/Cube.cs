using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    public event Action IsClicked;

    private void OnMouseUpAsButton()
    {
        IsClicked?.Invoke();
        Destroy(gameObject);
    }
}
