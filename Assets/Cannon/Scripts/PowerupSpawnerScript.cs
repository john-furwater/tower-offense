using UnityEngine;

public class PowerupSpawnerScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] powerups;
    [SerializeField]
    float spawnTime = 5f;

    void Start()
    {
        InvokeRepeating("SpawnPowerup", 0, spawnTime);
    }

    void SpawnPowerup()
    {
        Instantiate(GetNextPowerup(), transform);
    }

    GameObject GetNextPowerup()
    {
        return powerups[Random.Range(0, powerups.Length)];
    }
}
