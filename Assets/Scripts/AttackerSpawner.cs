using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] Attacker attackerPrefab;

    bool active = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (active)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity);
        newAttacker.transform.parent = transform;
    }
}
