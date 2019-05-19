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
    private string rotate = "Rotate";

    private float startXPos = 0.0f;
    private Quaternion startRotation;

    void Start()
    {
        horizontal += isPlayerOne ? "_P1" : "_P2";
        InvokeRepeating("SpawnNewBlock", spawnTime, spawnTime);
        startXPos = transform.position.x;
        startRotation = transform.rotation;
        rotate += isPlayerOne ? "_P1" : "_P2";
    }

    private void Update()
    {
        MoveSpawner(Input.GetAxis(horizontal));

        if (Input.GetButton(rotate))
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.forward, transform.rotation.z + 0.5f, Space.Self);
    }

    private void MoveSpawner(float direction)
    {
        var positionX = transform.position.x + (.1f * direction);

        transform.position = new Vector2(positionX, transform.position.y);
    }

    void SpawnNewBlock() {
        // reset block position
        transform.position = new Vector2(startXPos, transform.position.y);
        transform.rotation = startRotation;

        var newCrate = Instantiate(GetRandomBlock(), transform);

        newCrate.gameObject.tag = isPlayerOne ? "P1" : "P2";
    }

    private GameObject GetRandomBlock() {
        return BlockList[Random.Range(0, BlockList.Length-1)];
    }
}
