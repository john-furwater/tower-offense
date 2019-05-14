using UnityEngine;

public class CrateSpawnerScript : MonoBehaviour
{
    [SerializeField]
    GameObject crate;
    [SerializeField]
    float spawnTime = 5f;

    void Start()
    {
        InvokeRepeating("SpawnCrate", spawnTime, spawnTime);
    }

    void SpawnCrate() {
        Instantiate(crate, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }
}
