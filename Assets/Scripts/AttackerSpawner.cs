using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] Attacker[] attackerPrefabs;

    bool active = true;

    IEnumerator Start()
    {
        while (active)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            if (active)
            {
                SpawnAttacker();
            }
        }
    }

    public void StopSpawning()
    {
        active = false;
    }

    private void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, attackerPrefabs.Length);
        Attacker newAttacker = Instantiate(attackerPrefabs[attackerIndex], transform.position, Quaternion.identity);
        newAttacker.transform.parent = transform;
    }
}
