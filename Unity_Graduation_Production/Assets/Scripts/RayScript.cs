using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BING
{
    public class RayScript : MonoBehaviour
    {
        public List<GameObject> allGameObject = new List<GameObject>();
        public GameObject actingObject;
        Ray ray; //射線
        float raylength = 1.5f; //射線最大長度
        RaycastHit hit;
        private InteractableSystem interactableSystem; 
        private DialogueSystem dialogueSystem;
        // Start is called before the first frame update
        private void Awake()
        {
            dialogueSystem = GameObject.Find("畫布對話系統").GetComponent<DialogueSystem>();
        }
        
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // 在螢幕中間創建一條射線
            ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            RaycastHit hit;

            // 檢查射線是否碰撞到物體
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Interactable")))
            {
                if (actingObject == null)
                {
                    actingObject = hit.collider.gameObject;
                    interactableSystem = actingObject.GetComponent<InteractableSystem>(); //宣告目前觸發物件的InteractableSystem
                    actingObject.GetComponent<ObjectInfo>().objectCanva.GetComponent<Canvas>().enabled = true;
                    // 如果碰到的是可互動物件，顯示畫布
                    print("Yes");
                    // interactCanvas.gameObject.SetActive(true);

                }
                else if (hit.collider.gameObject != actingObject)
                {
                    foreach (var item in allGameObject)
                    {
                        item.gameObject.GetComponent<ObjectInfo>().objectCanva.GetComponent<Canvas>().enabled = false;
                    }
                    actingObject = null;
                }
                // 如果按下了指定的按鍵
                if (Input.GetKeyDown(KeyCode.F))
                {
                    print("觸發對話");
                    // 觸發對話的那段
                    
                    if (interactableSystem.propActive == null || interactableSystem.propActive.activeInHierarchy)
                    {
                        dialogueSystem.StartDialogue(interactableSystem.dataDialogue, interactableSystem.onDialogueFinish);
                    }
                    else
                    {
                        dialogueSystem.StartDialogue(interactableSystem.dataDialogueActive, interactableSystem.onDialogueFinishAfterActive);
                    }
                }
            }
            else
            {
                foreach (var item in allGameObject)
                {
                    item.gameObject.GetComponent<ObjectInfo>().objectCanva.GetComponent<Canvas>().enabled = false;
                }
                actingObject = null;
            }
        }
    }
}
