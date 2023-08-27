using UnityEngine;
using UnityEngine.Events;

namespace BING
{
    /// <summary>
    /// 互動系統 : 偵測玩家是否進入並且執行互動行為
    /// </summary>
    public class InteractableSystem : MonoBehaviour
    {
        public Canvas canvas;

        [SerializeField, Header("第一段對話資料")]
        private DialogueData dataDialogue;
        [SerializeField, Header("對話結束後的事件")]
        private UnityEvent onDialogueFinish;            // Unity 事件

        [SerializeField, Header("啟動道具")]
        private GameObject propActive;
        [SerializeField, Header("啟動後的對話資料")]
        private DialogueData dataDialogueActive;
        [SerializeField, Header("啟動後對話結束後的事件")]
        private UnityEvent onDialogueFinishAfterActive;

        private string nameTarget = "PlayerCapsule";
        private DialogueSystem dialogueSystem;

        private void Awake()
        {
            dialogueSystem = GameObject.Find("畫布對話系統").GetComponent<DialogueSystem>();
        }
        
        private void Start()
        {
            if (canvas != null)
            {
                canvas.enabled = false;
            }    
        }

        public void HitByRaycast() // 被射線打到時會進入此方法
        {
            if (Input.GetKeyDown(KeyCode.F)) // 當鍵盤按下 F 鍵時
            {
                if (propActive == null || propActive.activeInHierarchy)
                {
                    dialogueSystem.StartDialogue(dataDialogue, onDialogueFinish);
                }
                else
                {
                    dialogueSystem.StartDialogue(dataDialogueActive, onDialogueFinishAfterActive);
                }
            }
        }

        // 3D 物件適用
        // 兩個碰撞物件必須其中一個勾選 Is Trigger

        // 碰撞持續 (按鍵觸發)
        private void OnTriggerStay(Collider other)
        {
            if (other.name.Contains(nameTarget))
            {
                canvas.enabled = true;
                print(other.name);
                if (Input.GetKeyDown(KeyCode.F)) 
                { 
                    // 如果 不需要啟動道具 或者 啟動道具是顯示的 就執行 第一段對話
                    if (propActive == null || propActive.activeInHierarchy)
                    {
                        dialogueSystem.StartDialogue(dataDialogue, onDialogueFinish);
                    }
                    else
                    {
                        dialogueSystem.StartDialogue(dataDialogueActive, onDialogueFinishAfterActive);
                    }
                }
            }
        }

        // 碰撞開始 (剛體碰撞觸發)
        private void OnTriggerEnter(Collider other)
        {
            
        }

        // 碰撞結束
        private void OnTriggerExit(Collider other)
        {

        }

        /// <summary>
        /// 隱藏物件
        /// </summary>
        public void HiddenObject()
        {
            gameObject.SetActive(false);
        }
    }
}