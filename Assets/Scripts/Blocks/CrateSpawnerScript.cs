using System.Linq;
using UnityEditor;
using UnityEngine;

public class CrateSpawnerScript : MonoBehaviour
{
    [SerializeField]
    bool isPlayerOne = true;
    [SerializeField]
    CrateScript[] BlockList;
    [SerializeField]
    float spawnTime = 5f;
    string horizontal = "Horizontal2";
    private string rotate = "Rotate";
    private string rotateCounter = "RotateCounter";

    private float startXPos = 0.0f;
    private Quaternion startRotation;
    private CrateScript newBlock;

    void Start()
    {
        horizontal += isPlayerOne ? "_P1" : "_P2";
        InvokeRepeating("SpawnNewBlock", spawnTime, spawnTime);
        startXPos = transform.position.x;
        startRotation = transform.rotation;
        rotate += isPlayerOne ? "_P1" : "_P2";
        rotateCounter += isPlayerOne ? "_P1" : "_P2";
    }

    private void Update()
    {
        MoveSpawner(Input.GetAxis(horizontal));

        if (Input.GetButtonDown(rotate))
        {
            Rotate(true);
        }

        if (Input.GetButtonDown(rotateCounter))
        {
            Rotate(false);
        }
    }

    private void Rotate(bool counterClockwise)
    {
        if (newBlock == null || !newBlock.canControl) return;
        newBlock.transform.Rotate(Vector3.forward, counterClockwise ? 90f : -90f, Space.Self);
    }

    private void MoveSpawner(float direction)
    {
        if (newBlock == null || !newBlock.canControl) return;

        var positionX = newBlock.transform.position.x + (.1f * direction);

        newBlock.transform.position = new Vector2(positionX, newBlock.transform.position.y);
    }

    void SpawnNewBlock() {

        newBlock = Instantiate(GetRandomBlock(), transform);

        newBlock.gameObject.tag = isPlayerOne ? "P1" : "P2";
    }

    private CrateScript GetRandomBlock() {
        return BlockList[Random.Range(0, BlockList.Length-1)];
    }
}
