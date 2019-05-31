using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButtonScript : MonoBehaviour
{
    [SerializeField]
    Text buttonText;

    public void LoadScene()
    {
        SceneManager.LoadScene(buttonText.text);
    }
}
