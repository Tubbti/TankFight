using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
   public Tank[] tanks;
   public Color[] tankColor;
   [SerializeField]
   private GameObject TankPrefab;
   [SerializeField]
   private FollowTarget FollowTarget;
   public FocusCamera FocusCamera;
   public Focus1 Focus1;
   public Focus2 Focus2;
   [SerializeField]
   private Text messageText;
   public GameObject MainCamera;
    private GameObject camera_F;
    public GameObject camera_1;
    public GameObject camera_2;
   private TankManager tankManager;
   public int gameRoundCount = 2;
   public Color[] Colors;
   void OnEnable()
   {
        int skinColor1 = PlayerPrefs.GetInt("Color1");
        tankColor[0] = Colors[skinColor1];
        int skinColor2 = PlayerPrefs.GetInt("Color2");
        tankColor[1] = Colors[skinColor2];
        MainCamera = GameObject.Find("Main Camera");
        camera_F = GameObject.Find("Camera_F");
        camera_F.SetActive(false);
        MainCamera.SetActive(true);
        camera_1.SetActive(false);
        camera_2.SetActive(false);
        spawnTanks();
        initCamera();
        StartCoroutine(GameLoop());
   }
   public IEnumerator GameLoop()
   {
       yield return StartCoroutine(RoundStart());
       yield return StartCoroutine(RoundPlaying());
       yield return StartCoroutine(RoundEnd());

   }
   private IEnumerator RoundStart()
   { 
       camera_F.SetActive(false);
        MainCamera.SetActive(true);
        camera_1.SetActive(false);
        camera_2.SetActive(false);
       messageText.text = "回合     开始";
       tankManager.ResetTanks();
       tankManager.EnableTanks(false);
       yield return new WaitForSeconds(3);
   }
    private IEnumerator RoundPlaying()
   {
        FocusCameras();
        messageText.text = "";
        tankManager.EnableTanks(true);
        yield return new WaitUntil(tankManager.IsOneTankLeft);
   }
    private IEnumerator RoundEnd()
   {
       
       Tank roundWinner = tankManager.GetRoundWinner();
       roundWinner.IncreaseRoundWinnerCount();
       Tank roundLoser = tankManager.GetRoundLoser();
       Tank gameWinner = tankManager.GetGameWinner();
       FocusCamera.GetTarget(roundWinner.tankGameObject.transform);
       Focus_Camera();
       if(gameWinner != null)
       {
            messageText.text = "游戏    结束\n" + roundWinner.roundWinnerCount + "    :    " + roundLoser.roundWinnerCount + "\n\n\n按 ESC 退出";
            StopAllCoroutines();
       }
       else
       {
           messageText.text = "回合    结束\n" + roundWinner.roundWinnerCount + "    :    " + roundLoser.roundWinnerCount;
           yield return new WaitForSeconds(3);
           StartCoroutine(GameLoop());
       }
       
   }
   public void spawnTanks()
   {
       tankManager = new TankManager(gameRoundCount);

       for(int i=0;i<tanks.Length;i++)
       {
           Tank tank = tanks[i];
           GameObject tankGameObject = Instantiate(TankPrefab,tank.spawnPoint.position,Quaternion.identity);
           tank.Setup(tankGameObject,i+1,tankColor[i]);
            tankManager.AddTank(tank);
       }
   }
   public void initCamera()
   {
       Transform[] targets = tankManager.GetTanksTransforms();
       FollowTarget.SetTanksTransforms(targets);
   }
   public void Focus_Camera()
   {
       MainCamera.SetActive(false);
       camera_F.SetActive(true);
        camera_1.SetActive(false);
        camera_2.SetActive(false);
   }
   public void FocusCameras()
   {
        Transform target1 = tankManager.GetTank1Transform();
        Transform target2 = tankManager.GetTank2Transform();
       Focus1.GetTarget(target1);
       Focus2.GetTarget(target2);
       camera_F.SetActive(false);
       MainCamera.SetActive(false);
        camera_1.SetActive(true);
        camera_2.SetActive(true);
   }
 
 }
