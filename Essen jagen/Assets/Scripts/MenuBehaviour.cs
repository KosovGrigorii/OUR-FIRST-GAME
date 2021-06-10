using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        Intro.hint = 20;
        Intro.sceneName = sceneName;
    }
    
    public void ChangeScene1(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));

    }
    
    IEnumerator LoadLevel(string level)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
}
