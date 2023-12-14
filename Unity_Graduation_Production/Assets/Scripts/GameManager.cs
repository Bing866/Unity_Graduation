using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //使用unity的場景功能

public class GameManager : MonoBehaviour
{
    // 公開一個StartGame()等等會用到
    public void StartGame()
    {
        // 讀取場景名"遊戲場景" 名稱要一模一樣
        SceneManager.LoadScene("遊戲場景");

    }
    // 公開一個Menu()等等設定按鈕會用到
    public void Menu()
    {
        //讀取場景名稱"Menu" 名稱要一模一樣
        SceneManager.LoadScene("設定選單");
    }
    // 公開一個HomeScreen() 暫停選單的離開按鈕會用到
    public void HomeScreen()
    {
        //讀取場景名稱"開頭選單" 名稱要一模一樣
        SceneManager.LoadScene("開頭選單");
    }

    public GameObject pauseMenuUI; //公開一個暫停選單物件
    private bool isPaused = false;

    void Start()
    {
        // 在遊戲開始時先隱藏暫停選單
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape )) // 設定"Esc"為觸發按鍵
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f : 1f; // 遊戲暫停時凍結時間
            pauseMenuUI.SetActive(isPaused); // 顯示或隱藏暫停選單
        }
    }
}
