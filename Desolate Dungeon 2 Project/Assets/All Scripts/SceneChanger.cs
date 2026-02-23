using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger: MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void OpenSettings()
    {
        SceneManager.LoadSceneAsync(1);
    }


    public void QuitGame()
    {
        Debug.Log("Quit game");
    }
}
