/****************************************************
	�ļ���PrefabUtil.cs
	���ߣ�JiahaoWu
	����: jiahaodev@163.ccom
	���ڣ�2020/02/12 0:06   	
	���ܣ�Ԥ���������
*****************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrefabUtil
{

    public static GameObject create(string path, UnityObject obj, GameObject parentObj = null)
    {
#if _CLIENTLOGIC_
        GameObject gameObject = create(path);
        obj.m_gameObject = gameObject;

        if (parentObj != null)
        {
            obj.m_gameObject.transform.SetParent(parentObj.gameObject.transform);
        }

        return gameObject;
#else
        return null;
#endif
    }

    private static GameObject create(string path)
    {
        GameObject obj = (GameObject)GameObject.Instantiate(Resources.Load(path));

        return obj;
    }
}
