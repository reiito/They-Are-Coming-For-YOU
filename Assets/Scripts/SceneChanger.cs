using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadNewScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
