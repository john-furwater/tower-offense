using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public void LoadScene(int sceneSelector)
    {
        SceneManager.LoadScene(sceneSelector);
    }
}
