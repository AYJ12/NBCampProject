using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    //public LevelList levelList;
    public static GameManager s_instance = null;
    public static GameManager Instance { get; protected set; }

    private static ResourceManager s_resourceManager = new ResourceManager();
    private static SceneManagerP s_sceneManager = new SceneManagerP();
    private static UIManager s_uiManager = new UIManager();
    //private static PoolManager s_poolManager = new PoolManager();
    private static GameManager s_gameManager = new GameManager();

    public static ResourceManager Resource { get { Init(); return s_resourceManager; } }
    public static UIManager UI { get { Init(); return s_uiManager; } }

    //public static PoolManager Pool { get { Init(); return s_poolManager; } }
    public static bool instanceExists
    {
        get { return s_instance != null; }
    }

    protected virtual void Awake()
    {
        if (instanceExists)
        {
            Destroy(gameObject);
        }
        else
        {
            s_instance = (GameManager)this;
        }
        Init();
    }

    private static void Init()
    {
        //PlayerPrefs.DeleteAll();
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("GameManager");
            if (go == null)
                go = new GameObject { name = "Managers" };

            s_instance = Utils.GetOrAddComponent<GameManager>(go);

            DontDestroyOnLoad(go);

            s_resourceManager.Init();
            Application.targetFrameRate = 60;
        }
    }

    //public void CompleteLevel(string levelId, int starsEarned)
    //{
    //    if (!levelList.ContainsKey(levelId))
    //    {
    //        Debug.LogWarningFormat("[GAME] Cannot complete level with id = {0}. Not in level list", levelId);
    //        return;
    //    }

    //    m_DataStore.CompleteLevel(levelId, starsEarned);
    //    SaveData();
    //}

    //public LevelItem GetLevelForCurrentScene()
    //{
    //    string sceneName = SceneManager.GetActiveScene().name;

    //    return levelList.GetLevelByScene(sceneName);
    //}


    //public bool IsLevelCompleted(string levelId)
    //{
    //    if (!levelList.ContainsKey(levelId))
    //    {
    //        Debug.LogWarningFormat("[GAME] Cannot check if level with id = {0} is completed. Not in level list", levelId);
    //        return false;
    //    }

    //    return m_DataStore.IsLevelCompleted(levelId);
    //}


    //public int GetStarsForLevel(string levelId)
    //{
    //    if (!levelList.ContainsKey(levelId))
    //    {
    //        Debug.LogWarningFormat("[GAME] Cannot check if level with id = {0} is completed. Not in level list", levelId);
    //        return 0;
    //    }

    //    return m_DataStore.GetNumberOfStarForLevel(levelId);
    //}
}
