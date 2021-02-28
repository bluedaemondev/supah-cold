using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIScript : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject levelSelectPanel;

    public string redSocialLink1 = "http://instagram.com/bluedaemonart";
    public string redSocialLink2 = "https://www.youtube.com/channel/UC6yn5SLH7tFb5_-hEPkfx3Q";


    private void Start()
    {
        ShowMainMenu();
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
    }

    public void SocialLink1()
    {
        Application.OpenURL(redSocialLink1);
    }
    public void SocialLink2()
    {
        Application.OpenURL(redSocialLink2);
    }

    public void ShowMainMenu()
    {
        mainPanel.SetActive(true);

        settingsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
    }
    
    public void ShowSettings()
    {
        settingsPanel.SetActive(true);

        mainPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
    }
    public void ShowLevelSelection()
    {
        levelSelectPanel.SetActive(true);

        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    public void PlayScene(string nameScene)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("MainMenu"));
        SceneManager.LoadScene(nameScene);
    }
    public void PlayNextScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("MainMenu"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        Debug.Log("Exiting game");
#if UNITY_STANDALONE || UNITY_EDITOR
        Application.Quit();
#endif
    }
}