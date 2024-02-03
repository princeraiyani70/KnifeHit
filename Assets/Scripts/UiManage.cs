using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManage : MonoBehaviour
{
    public GameObject restartBtn, pausePanel;

    [Header("Knife Cound Display")]

    public GameObject panelKnifes;
    public GameObject knifeIcon;
    public Color usedKnifesIconColor;

    public void ShowRestartBtn()
    {
        Time.timeScale = 0;
        restartBtn.SetActive(true);
    }

    public void SetInitialDisplayKnifeCount(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(knifeIcon, panelKnifes.transform);
        }
    }

    public int KnifeIconIndexToChange = 0;
    public void DecrementDisplayKnifeCount()
    {
        panelKnifes.transform.GetChild(KnifeIconIndexToChange++).gameObject.GetComponent<Image>().color = usedKnifesIconColor;
    }

    public void PauseBtn()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
}
