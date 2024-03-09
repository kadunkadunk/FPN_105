using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  
   public void LoadSceneByName(string sceneName)
    {
        Debug.Log("Scene loaded");
        SceneManager.LoadScene(sceneName);
   }
}
