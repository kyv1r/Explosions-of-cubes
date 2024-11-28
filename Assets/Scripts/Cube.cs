using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Recolorer _recolorer;
    [SerializeField] private Fuse _fuse;

    public Renderer Renderer { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public float Chance = 100;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
    }

    public void OnEnable()
    {
        _inputManager.Clicked += CoordinateAction;
    }

    public void OnDisable()
    {
        _inputManager.Clicked -= CoordinateAction;
    }

    public void CoordinateAction()
    {
        if (TryCreate() == false)
        {
            _fuse.ExplodeCubes(this);
            Destroy(gameObject);
            return;
        }

        List<Cube> newCubes = _spawner.Create(this);
        _recolorer.PaintCubes(newCubes);
        Destroy(gameObject);
    }

    public void Initialize(float chance)
    {
        Chance = chance;
    }

    private bool TryCreate()
    {
        float lowChance = 0;
        float highChance = 100;
        float chance = UnityEngine.Random.Range(lowChance, highChance);

        if (chance <= Chance)
            return true;

        return false;
    }
}
