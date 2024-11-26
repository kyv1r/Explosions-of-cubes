using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Spawn : MonoBehaviour
{
    [SerializeField] private Fuse _fuse;

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
        int _lowCountCubes = 2;
        int _highCountCubes = 6;

        int countCubes = Random.Range(_lowCountCubes, _highCountCubes + 1);

        if (CalculateChance())
        {
            GameObject newObject = _fuse.gameObject;
            Resize(newObject);

            for (int i = 0; i < countCubes; i++)
            {
                Instantiate(newObject);
                Debug.Log("Выпало " + countCubes + " куба");
            }
        }
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
