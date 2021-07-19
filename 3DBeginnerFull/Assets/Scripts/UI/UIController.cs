using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoSingleton<UIController>
{
    public Image[] bloods;
    public GameObject CursorRed;
    private PlayerMovement m_player;
    private Sprite redHP;
    private Sprite yellowHP;
    public Texture2D cursorTexture;

    private void Start()
    {
        m_player = GameObject.Find("JohnLemon").GetComponent<PlayerMovement>();
        redHP = Resources.Load<Sprite>("UI/HP/HP icon red");
        yellowHP = Resources.Load<Sprite>("UI/HP/HP icon");
    }
    public void UpdateBlood()
    {
        if (m_player.Huted.blood >= 0)
        {
            Debug.Log(m_player.Huted.blood);
            StartCoroutine(BloodDisappear(bloods[(int)m_player.Huted.blood]));
        }
        else{
            Debug.Log("血量异常");
        }

    }

    IEnumerator BloodDisappear(Image hp)
    {
        for (int i = 0; i < 2; i++)
        {
            hp.sprite = yellowHP;
            yield return new WaitForSeconds(0.2f);
            hp.sprite = redHP;
            yield return new WaitForSeconds(0.2f);
        }
        hp.gameObject.SetActive(false);
    }

    public void CursorDown(){
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void CursorUp(){
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
