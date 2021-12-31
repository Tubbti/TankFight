using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject BottonReload;
    public GameObject BottonExit;
    public GameObject GameMenu;
    public Text TextClock;
    private float m_Timer;
    private int m_Minute;
    private int m_Second;
    private bool flag = false;
    void Start()
    {
        PauseMenu.SetActive(false);
        BottonReload.GetComponent<Button>().onClick.AddListener(OnReload);
        BottonExit.GetComponent<Button>().onClick.AddListener(OnExit);
    }
    void Update()
    {
        m_Timer += Time.deltaTime;
        m_Second = (int)m_Timer;
        if(m_Second > 59.0f)
        {
            m_Second = (int)(m_Timer - (m_Minute * 60));
        }
        m_Minute = (int)m_Timer/60;
        TextClock.text = string.Format("用时:{0:d2}:{1:d2}",m_Minute,m_Second); 
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!flag)
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
                flag = true;
            }
            else {
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
                flag = false;
            }
        }
    }

    public void OnReload()
    {
       SceneManager.LoadScene("Main");
    }
  
    public void OnExit()
    {
        Application.Quit();
    }
}
