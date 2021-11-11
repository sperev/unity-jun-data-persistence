using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField] TMP_Text bestScoreText;
    [SerializeField] Button startButton;
    [SerializeField] Button exitButton;
    [SerializeField] TMP_InputField nameField;

    // Start is called before the first frame update
    void Start()
    {
        var player = StatsController.Instance.topPlayer;

        if (player != null)
        {
            bestScoreText.text = "Best Score" + (player.score > 0 ? ": " + player.score.ToString() : "");
        }
        

        if (StatsController.Instance.currentPlayerName != null)
        {
            nameField.text = StatsController.Instance.currentPlayerName;
        }
    }

    public void OnStartPressed()
    {
        StatsController.Instance.currentPlayerName = nameField.text;
        SceneManager.LoadScene(1);
    }

    public void OnExitPressed()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void OnNameFieldTextChanged()
    {
        startButton.interactable = nameField.text.Length > 2;
    }
}
