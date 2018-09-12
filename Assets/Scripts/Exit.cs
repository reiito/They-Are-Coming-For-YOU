using UnityEngine;

public class Exit : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
