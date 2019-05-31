using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    float buttonVerticalOffset = -40;
    [SerializeField]
    GameObject sceneButton;
    Transform _transform;

    void Awake()
    {
        _transform = transform;
        AddSceneButtons();
    }

    void AddSceneButtons()
    {
        var sceneCount = SceneManager.sceneCountInBuildSettings;

        for (int ii = 0; ii < sceneCount; ii++)
        {
            var sceneName = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(ii));

            if (sceneName != SceneManager.GetActiveScene().name)
                AddSceneButton(sceneName, ii);
        }
    }

    private void AddSceneButton(string sceneName, int index)
    {
        var button = Instantiate(
            sceneButton,
            GetButtonPosition(index),
            Quaternion.identity,
            _transform);

        button.GetComponentInChildren<Text>().text = sceneName;
    }

    private Vector3 GetButtonPosition(int index)
    {
        var position = _transform.position;
        var yOffset = position.y + index * buttonVerticalOffset;

        return new Vector3(position.x, yOffset, position.z);
    }
}
