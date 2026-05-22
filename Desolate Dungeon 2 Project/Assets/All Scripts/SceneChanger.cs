using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger: MonoBehaviour
{
    AudioController audioController;

    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();



    }




    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
        audioController.PlaySFX(audioController.buttonclick);
    }

    public void OpenSettings()
    {
        SceneManager.LoadSceneAsync(1);
        audioController.PlaySFX(audioController.buttonclick);
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
        audioController.PlaySFX(audioController.returnbuttonclick);
    }

    public void ExitSettings()
    {
        SceneManager.LoadSceneAsync(0);
        audioController.PlaySFX(audioController.returnbuttonclick);
    }

    public void ReplayGame()
    {
        SceneManager.LoadSceneAsync(2);         
    }
}
