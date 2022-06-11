using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public Animator Anim;
    public float ScrollDuration=0.5f;
    RectTransform rectTransform;
    int size;
    int currChild = 0;
    Vector2 startPos;
    Vector2 endPos;
    bool scroll;
    float timer;
    bool freezeButtons;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        size = (int)rectTransform.rect.width / rectTransform.childCount;
        startPos = rectTransform.anchoredPosition;
    }
    private void Update()
    {
        if (scroll)
        {
            
            timer += Time.deltaTime;
            float fraction = timer / ScrollDuration;
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, fraction);
            if (timer >= ScrollDuration)
            {
                rectTransform.anchoredPosition = endPos;
                timer = 0;
                scroll = false;
                freezeButtons = false;
            }
        }
    }



    public void OnLeft()
    {
        if (currChild > 0 && !freezeButtons)
        {
            scroll = true;
            startPos = rectTransform.anchoredPosition;
            endPos= new Vector2(rectTransform.anchoredPosition.x+size, rectTransform.anchoredPosition.y);
            currChild--;
            freezeButtons = true;
        }
    }

    public void OnRight()
    {
        if (currChild < rectTransform.childCount - 1 && !freezeButtons)
        {
            scroll = true;
            startPos = rectTransform.anchoredPosition;
            endPos = new Vector2(rectTransform.anchoredPosition.x-size, rectTransform.anchoredPosition.y);
            currChild++;
            freezeButtons = true;
        }
    }

    public void OnShowButton()
    {
        bool state = Anim.GetBool("Show");
        if (state)
            EventSystem.current.SetSelectedGameObject(null);

        Anim.SetBool("Show", !state);
    }
}
