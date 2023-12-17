﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //使用unity的場景功能

public class GameManager : MonoBehaviour
{
    // 公開一個StartGame()選項給"開始按鈕"觸發事件使用
    public void StartGame()
    {
        // 讀取場景名"遊戲場景" 名稱要一模一樣
        SceneManager.LoadScene("遊戲場景");
        // 點擊"開始遊戲"按鈕後鎖定游標
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // 公開一個Menu()選項給"設定按鈕"觸發事件使用
    public void Menu()
    {
        //讀取場景名稱"Menu" 名稱要一模一樣
        SceneManager.LoadScene("設定選單");
    }
    // 公開一個HomeScreen()選項給"暫停選單的離開遊戲按鈕"觸發事件使用
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
        if (Input.GetKeyDown(KeyCode.Escape )) // 設定"Esc"為暫停選單觸發按鍵
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f : 1f; // 遊戲暫停時凍結時間
            pauseMenuUI.SetActive(isPaused); // 顯示或隱藏暫停選單

            // 觸發暫停選單後解鎖游標
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void OnResume() //點擊繼續遊戲的執行方法
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        
        // 點擊"繼續遊戲"按鈕後鎖定游標
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
