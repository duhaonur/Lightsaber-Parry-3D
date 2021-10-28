using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{
    private float transition = 0.0f;

    private bool isLevelEnd = false;

    public Image backgroundImg;

    public GameObject levelEndPanel;
    public GameObject playAgainButton;

    private void Update()
    {
        if (!isLevelEnd)
            return;
        transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Color32(0, 0, 0, 0), new Color32(0, 0, 0, 255), transition);
    }

    public void EndTheGame()
    {
        isLevelEnd = true;
        playAgainButton.SetActive(true);
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene(1);
    }
}
