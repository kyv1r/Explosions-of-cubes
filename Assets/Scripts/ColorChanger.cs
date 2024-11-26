using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Spawn _spawn;

    private Renderer _renderer;

    private void Start()
    {
        Recolor(_spawn.gameObject);
    }

    private void Recolor(GameObject gameObject)
    {
        _renderer.material.color = Color.black;
    }
}
