using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        Time.timeScale = 1;
    }
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    public void Player()
    {
        ScoreScript.scoreValue = 0;
        Time.timeScale = 1;
        CheckGameOver.check = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}