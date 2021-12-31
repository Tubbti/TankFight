using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LobbyMenu : MonoBehaviour
{
    public GameObject ButtonPlay;
    public GameObject ButtonQuit;
    public GameObject ButtonNext;
    public GameObject ButtonOption;
    public GameObject Menu;
    public GameObject ButtonChangeSkin1;
    public GameObject ButtonChangeSkin2;
    public GameObject ChangeSkinCamera;
    public GameObject MCamera;
    public Text Titles;
    public GameObject TipManager;
    public Text Tip;
    private StreamReader sr;
    public GameObject tank1;
    public GameObject tank2;
    public Color[] Colors;
    private int color1;
    private int color2;
    private int i1=0,i2=0;
    private int lineCount = 0;
   
    private IEnumerator Display()
    {
        sr = new StreamReader(Application.dataPath + "/text.txt");
        //创建一个流，用于读取行数
        StreamReader srLine = new StreamReader(Application.dataPath + "/text.txt");
        //循环来读取行数，直到为null停止
        while (srLine.ReadLine() != null)
        {
            lineCount++;
        }
        //关闭并释放流
        srLine.Close();
        srLine.Dispose();
        for (int i = 0; i < lineCount; i++)
        {
            string tempText = sr.ReadLine();
            Titles.text = tempText.Split('$')[0];
            Debug.Log(Titles.text);
            float tempTime;
            if (float.TryParse(tempText.Split('$')[1], out tempTime))
            {
                //协程等待
                yield return new WaitForSeconds(tempTime);
            }
        }
        //关闭并释放流
        sr.Close();
        sr.Dispose();
    }
    // Update is called once per frame
    void Update()
    {
        MCamera.transform.Rotate(new Vector3(0,0.3f,0),Space.Self);
    }
    void Start()
    {
        //Colors = new Color[6]{Color.blue,Color.red,Color.green,Color.yellow,Color.grey,Color.white};
        ChangeSkinCamera.SetActive(false);
        Tip.text = "第一次游玩请务必点击这里";
        ButtonPlay.GetComponent<Button>().onClick.AddListener(_Play);
        ButtonQuit.GetComponent<Button>().onClick.AddListener(_Quit);
        ButtonNext.GetComponent<Button>().onClick.AddListener(_Next);
        ButtonOption.GetComponent<Button>().onClick.AddListener(_Option);
        ButtonChangeSkin1.GetComponent<Button>().onClick.AddListener(_ChangeSkin1);
        ButtonChangeSkin2.GetComponent<Button>().onClick.AddListener(_ChangeSkin2);
    }
    private void _Play()
    {
        PlayerPrefs.SetInt("Color1",color1);
        PlayerPrefs.SetInt("Color2",color2);
        SceneManager.LoadScene("Main");
    }    
    private void _Next()
    {
        Menu.SetActive(true);
        ChangeSkinCamera.SetActive(false);
        MCamera.SetActive(true);
        ButtonOption.SetActive(false);
        TipManager.SetActive(false);
        ButtonPlay.SetActive(false);
        StartCoroutine(Display());
        Invoke("ShowPlay",25);
    }
    private void _Option()
    {
        Menu.SetActive(false);
        MCamera.SetActive(false);
        ChangeSkinCamera.SetActive(true);
    }
    private void ShowPlay()
    {
        ButtonPlay.SetActive(true);
    }
    private void _Quit()
    {
        Application.Quit();
    }
    public void _ChangeSkin1()
    {
        if(i1<Colors.Length - 1)
        {
            color1 = i1;
            ChangeTankColor(Colors[i1],tank1);
            i1++;
        }
        else
        {
            color1 = i1;
            ChangeTankColor(Colors[i1],tank1);
            i1=0;
        }
    }
    public void _ChangeSkin2()
    {
        if(i2<Colors.Length - 1)
        {
            color2 = i2;
            ChangeTankColor(Colors[i2],tank2);
            i2++;
        }
        else
        {
            color2 = i2;
            ChangeTankColor(Colors[i2],tank2);
            i2=0;
        }
    }
    private void ChangeTankColor(Color color,GameObject tank)
    {
        MeshRenderer[] renderers = tank.GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer renderer in renderers)
        {
            renderer.material.color = color;
        }
    }
}
