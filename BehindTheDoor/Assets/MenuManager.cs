using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public SceneAsset gameScene;
    public SceneAsset menuScene;
    public GameObject menuGameObject;

    private string SceneName(SceneAsset scene)
    {
        return scene.name;
    }

    public void OnStart()
    {
        SceneManager.LoadScene(SceneName(gameScene));
    }

    public void OnMenu()
    {
        SceneManager.LoadScene(SceneName(menuScene));
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void ToggleEnableMenu()
    {
        bool enabled = menuGameObject.activeSelf;
        menuGameObject.SetActive(!enabled);
    }
}
