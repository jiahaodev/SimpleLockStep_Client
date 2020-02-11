/****************************************************
	�ļ���BattleUI.cs
	���ߣ�JiahaoWu
	����: jiahaodev@163.ccom
	���ڣ�2020/02/12 0:09   	
	���ܣ�ս��UI
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{

    public Button btnStartBattle;
    public Button btnSendSoldier;
    public Button btnEndBattle;
    public Button btnReplay;
    public Button btnAdjustSpeed;
    public Text textResult;
    public static string m_scServerInfo = "";

    public BattleLogicMonoBehaviour monoBehaviour;

    // Use this for initialization
    void Start()
    {
        btnStartBattle = btnStartBattle.GetComponent<Button>();
        btnSendSoldier = btnSendSoldier.GetComponent<Button>();
        btnEndBattle = btnEndBattle.GetComponent<Button>();
        btnReplay = btnReplay.GetComponent<Button>();
        var txtAdjustSpeed = btnAdjustSpeed.transform.Find("Text").GetComponent<Text>();
        btnAdjustSpeed = btnAdjustSpeed.GetComponent<Button>();
        textResult = textResult.GetComponent<Text>();

        var battleLogic = monoBehaviour.getBattleLogic();


        //��ʼս��
        btnStartBattle.onClick.AddListener(delegate ()
        {
            textResult.text = "������У����:--";
            GameData.g_bReplayMode = false;
            battleLogic.startBattle();
        });

        //����
        btnSendSoldier.onClick.AddListener(delegate ()
        {
            battleLogic.createSoldier();
        });

        //ֹͣս��
        btnEndBattle.onClick.AddListener(delegate ()
        {
            battleLogic.stopBattle();
        });

        //�ط�ս��¼��
        btnReplay.onClick.AddListener(delegate ()
        {
            battleLogic.setBattleRecord(UnityTools.playerPrefsGetString("battleRecord"));
            battleLogic.replayVideo();
        });

        //����ս���ٶ�
        btnAdjustSpeed.onClick.AddListener(delegate ()
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 2;
                txtAdjustSpeed.text = "2����";
            }
            else if (Time.timeScale == 2)
            {
                Time.timeScale = 4;
                txtAdjustSpeed.text = "4����";
            }
            else if (Time.timeScale == 4)
            {
                Time.timeScale = 1;
                txtAdjustSpeed.text = "1����";
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (m_scServerInfo != "")
        {
            if (BattleLogic.s_uGameLogicFrame == int.Parse(m_scServerInfo))
            {
                textResult.text = "������У��ɹ�";
            }
            else
            {
                textResult.text = "������У��ʧ��";
            }

            m_scServerInfo = "";
        }
    }
}
