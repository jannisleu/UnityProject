using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private GameObject _enemyPrefab;

    private float _delay = 0.5f;
    private bool _alive = true;
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(SpawnSystem());
    }

    // Update is called once per frame
    public void onPlayerDeath()
    {
         _alive = false;
    }

    IEnumerator SpawnSystem()
    {
        // SPAWNING
        while (_alive)
        {
            Instantiate(_enemyPrefab, new Vector3(Random.Range(-20f, 8f), 20f, 0), Quaternion.identity);
            yield return new WaitForSeconds(_delay);
        }

        yield return null;
    }
}
