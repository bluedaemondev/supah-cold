using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMulti : MonoBehaviour
{
    public static SceneManagerMulti instance { get; private set; }

    public string staticFolderName = "Static";
    public int staticSceneCountInBuildSettings = 3;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        var thisScene = SceneManager.GetActiveScene();

        // load all scenes
        for (int i = 0; i < staticSceneCountInBuildSettings; i++)
        {
            // skip if is current scene since we don't want it twice
            if (thisScene.buildIndex == i) continue;

            // Skip if scene is already loaded
            if (SceneManager.GetSceneByBuildIndex(i).IsValid()) continue;

            //var sc = SceneManager.GetSceneByBuildIndex(i);
            //print(sc.name);

            //if (sc.path.Contains(staticFolderName))
            //{
            SceneManager.LoadScene(i, LoadSceneMode.Additive);


            //}
            // or depending on your usecase
            //SceneManager.LoadSceneAsync(i, LoadSceneMode.Additive);
        }
        StartCoroutine(SetLastSceneAsActive());
    }

    public void LoadScene(int buildIndex = 0)
    {
        SceneManager.LoadScene(buildIndex);
    }
    public void LoadNextScene(string buildIndex = "")
    {
        Scene scLast = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(scLast.buildIndex);
        SceneManager.LoadScene(scLast.buildIndex + 1, LoadSceneMode.Additive);
        StartCoroutine(SetLastSceneAsActive());
    }

    public void ReLoadLastScene()
    {
        Scene scLast = SceneManager.GetActiveScene();

        SceneManager.UnloadSceneAsync(scLast.buildIndex);
        SceneManager.LoadScene(scLast.buildIndex, LoadSceneMode.Additive);
        StartCoroutine(SetLastSceneAsActive());

    }

    IEnumerator SetLastSceneAsActive()
    {
        yield return new WaitForSeconds(1);
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(SceneManager.sceneCount - 1));
        Debug.Log(SceneManager.GetSceneAt(SceneManager.sceneCount - 1).name);
    }
}
