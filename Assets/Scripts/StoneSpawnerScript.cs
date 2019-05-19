using UnityEngine;

public class StoneSpawnerScript : MonoBehaviour
{
    [SerializeField]
    GameObject stone;
    [SerializeField]
    float spawnTime = 3f;

    void Start()
    {
        InvokeRepeating("SpawnStone", spawnTime, spawnTime);
    }

    void SpawnStone()
    {
        Instantiate(stone, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }
}
