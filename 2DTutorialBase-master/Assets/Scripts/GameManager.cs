using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    #region Unity_functions
    private void Awake(){
        if(instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    #region Scene_transitions
    private void StartGame(){
        SceneManager.LoadScene("SampleScene");
    }
    private void LoseGame(){
        SceneManager.LoadScene("LoseScene");
    }
    private void WinGame(){
        SceneManager.LoadScene("WinScene");
    }
    private void MainGame(){
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
}
