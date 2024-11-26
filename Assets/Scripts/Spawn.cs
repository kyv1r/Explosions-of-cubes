using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Spawn : MonoBehaviour
{
    [SerializeField] private Fuse _fuse;
    [SerializeField] private List<GameObject> newObjects;

    private static int _maxChance = 100;

    private void OnEnable()
    {
        _fuse.IsDestroyed += Create;
    }

    private void OnDisable()
    {
        _fuse.IsDestroyed -= Create;
    }

    private void Create()
    {
        foreach (var newGameObject in GetNewObjects())
            Instantiate(newGameObject);

    }

    public List<GameObject> GetNewObjects()
    {
        newObjects.Clear();

        int _lowCountCubes = 2;
        int _highCountCubes = 6;

        int countCubes = Random.Range(_lowCountCubes, _highCountCubes + 1);

        if (CalculateChance())
        {
            GameObject newObject = _fuse.gameObject;
            Resize(newObject);

            for (int i = 0; i < countCubes; i++)
            {
                newObjects.Add(newObject);
                Debug.Log("Выпало " + countCubes + " кубов");
            }
        }

        return newObjects;
    }

    public List<Collider> GetCollidersObjects()
    {
        List<Collider> collisionsGameObjects = new();

        foreach (var newGameObject in GetNewObjects())
        {
            collisionsGameObjects.Add(newGameObject.GetComponent<Collider>());
        }

        return collisionsGameObjects;
    }

    private void Resize(GameObject gameObject)
    {
        gameObject.transform.localScale /= 2;
    }

    private bool CalculateChance()
    {
        int lowChance = 0;
        int highChance = 100;

        int chance = Random.Range(lowChance, highChance + 1);

        if (chance < _maxChance)
        {
            Debug.Log($"Выпало {chance} из {_maxChance}. Повезло!");
            _maxChance /= 2;
            return true;
        }

        Debug.Log($"Выпало {chance} из {_maxChance}. Не повезло!");

        return false;
    }
}
