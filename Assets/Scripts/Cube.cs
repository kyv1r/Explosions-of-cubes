using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Fuse _fuse;

    private float _chanceDisintegration = 100;

    public event Action<Cube> �racked;

    public Renderer Renderer { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public float ChanceDisintegration { get { return _chanceDisintegration; } }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _inputManager.Clicked += CoordinateAction;
    }

    private void OnDisable()
    {
        _inputManager.Clicked -= CoordinateAction;
    }

    public void Initialize(float chance)
    {
        _chanceDisintegration = chance;
    }

    private bool CalculateChanceCreate()
    {
        float lowChance = 0;
        float highChance = 100;
        float chance = UnityEngine.Random.Range(lowChance, highChance);

        if (chance <= _chanceDisintegration)
        {
            Debug.Log($"{chance} �� {_chanceDisintegration}");
            return true;
        }

        Debug.Log($"{chance} �� {_chanceDisintegration}");
        return false;
    }

    private void CoordinateAction()
    {
        if (CalculateChanceCreate() == true)
        {
            �racked?.Invoke(this);
            Destroy(gameObject);
            return;
        }

        _fuse.ExplodeCubes(this);
        Destroy(gameObject);
    }
}
