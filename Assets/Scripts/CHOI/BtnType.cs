using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BtnType : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {

    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defalutScale;
    public CanvasGroup MainGroup;
    public CanvasGroup OptionGroup;

    private void Start()
    {
        defalutScale = buttonScale.localScale;
        
        PlayerPrefs.SetInt("Stage", 1); // 시작할때 스테이지 1으로 세팅. --> 아무것도 안떠서 수정.
      
    }
    bool isSound = true;
    
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.New:
                PlayerPrefs.SetInt("Stage", 1); // 처음으로.
                SceneLoad.LoadScenehandle("NEW GAME", 0);
                break;
            case BTNType.Continue:
                PlayerPrefs.SetInt("Stage", stageManager.stage_record); // 저장해둔 스테이지 값으로 세팅.
                SceneLoad.LoadScenehandle("CONTINUE", 1);
                break;
            case BTNType.Option:
                CanvasGroupOn(OptionGroup);
                CanvasGroupOff(MainGroup);
                break;
            case BTNType.Quit:
                Application.Quit();
                break;
            case BTNType.Sound:
                if(isSound)
                {
                    isSound = !isSound;
                    AudioListener.volume = 0;

                }
                else
                {
                    isSound = !isSound;
                    AudioListener.volume = 1;
                }
                break;
            case BTNType.Back:
                CanvasGroupOn(MainGroup);
                CanvasGroupOff(OptionGroup);
                break;
        }

    }
    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defalutScale * 1.3f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defalutScale;
    }
    
}
