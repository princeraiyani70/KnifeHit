using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UiManage))]
public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    public int knifeCount;

    [Header("Knife Spawning")]

    public Vector2 knifespawnPosition;
    public GameObject knifeObject;

    public UiManage GameUI;
    private void Awake()
    {
        instance = this;
        GameUI = GetComponent<UiManage>();
    }

    private void Start()
    {
        GameUI.SetInitialDisplayKnifeCount(knifeCount);
        SpawnKnife();
    }

    public void OnSucessFukKnifeHit()
    {
        if(knifeCount > 0)
        {
            SpawnKnife();
        }
        else
        {
            StartGameOverSequence(true);
        }
    }

    public void SpawnKnife()
    {
        knifeCount--;
        Instantiate(knifeObject, knifespawnPosition, Quaternion.identity);

    }



    public void StartGameOverSequence(bool win)
    {
        StartCoroutine(GameOverSequintionCoroutine(win));
    }

    private IEnumerator GameOverSequintionCoroutine(bool win)
    {
        if(win)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            RestartGame();
        }
        else
        {
            Debug.Log("HUSDB ");
            GameUI.ShowRestartBtn();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
}
