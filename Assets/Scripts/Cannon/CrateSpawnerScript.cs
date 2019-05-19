using System.Linq;
using UnityEditor;
using UnityEngine;

public class CrateSpawnerScript : MonoBehaviour
{
    [SerializeField]
    bool isPlayerOne = true;
    [SerializeField]
    GameObject[] BlockList;
    [SerializeField]
    float spawnTime = 5f;
    string horizontal = "Horizontal2";

    private float startXPos = 0.0f;

    void Start()
    {
        horizontal += isPlayerOne ? "_P1" : "_P2";
        InvokeRepeating("SpawnNewBlock", spawnTime, spawnTime);
        startXPos = transform.position.x;
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

    void SpawnNewBlock() {
        // reset block position
        transform.position = new Vector2(startXPos, transform.position.y);
        var newCrate = Instantiate(GetRandomBlock(), transform);

        newCrate.gameObject.tag = isPlayerOne ? "P1" : "P2";
    }

    private GameObject GetRandomBlock() {
        return BlockList[Random.Range(0, BlockList.Length-1)];
    }
}
