/****************************************************
	文件：BattleLogicMonoBehaviour.cs
	作者：JiahaoWu
	邮箱: jiahaodev@163.ccom
	日期：2020/02/12 0:12   	
	功能：战斗对象挂载脚本
*****************************************************/

using UnityEngine;
using System.Collections;

public class BattleLogicMonoBehaviour : MonoBehaviour {

    BattleLogic battleLogic = new BattleLogic();


    void Start()
    {
#if _CLIENTLOGIC_
        battleLogic.init();
#else
        GameData.g_uGameLogicFrame = 0;
        GameData.g_bRplayMode = true;
        battleLogic.init();
        battleLogic.updateLogic();
#endif
    }


    void Update()
    {
#if _CLIENTLOGIC_
        battleLogic.updateLogic();
#endif
    }

    public BattleLogic getBattleLogic()
    {
        return battleLogic;
    }
}