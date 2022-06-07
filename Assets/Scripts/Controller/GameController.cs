using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    static public GameController instance;

    [SerializeField] private GameObject deathPanel;
    [SerializeField] private Text killAmountText;
    private int killAmount = 0;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void UpdateKillAmount()
    {
        killAmount++;
        killAmountText.text = killAmount.ToString();
    }
    
    public void ShowDeathPanel()
    {
        deathPanel.SetActive(true);
    }

    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
