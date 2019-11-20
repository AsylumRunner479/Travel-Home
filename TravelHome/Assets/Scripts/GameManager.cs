using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
   public void NextScene()
  {
    Scene activeScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(activeScene.buildIndex + 1);
  }
    public void Reset()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex);
    }
}
