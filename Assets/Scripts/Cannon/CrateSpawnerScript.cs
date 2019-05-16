using UnityEngine;

public class CrateSpawnerScript : MonoBehaviour
{
    [SerializeField]
    bool isPlayerOne = true;
    [SerializeField]
    GameObject crate;
    [SerializeField]
    float spawnTime = 5f;
    string horizontal = "Horizontal2";

    void Start()
    {
        horizontal += isPlayerOne ? "_P1" : "_P2";
        InvokeRepeating("SpawnCrate", spawnTime, spawnTime);
    }

    private void Update()
    {
        MoveSpawner(Input.GetAxis(horizontal));
    }

    private void MoveSpawner(float direction)
    {
        var positionX = transform.position.x + (.1f * direction);

        transform.position = new Vector2(positionX, transform.position.y);
    }

    void SpawnCrate() {
        var newCrate = Instantiate(crate, transform);

        newCrate.gameObject.tag = isPlayerOne ? "P1" : "P2";
    }
}
