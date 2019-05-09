using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{

    [SerializeField] float baseLives = 3f;
    [SerializeField] int damageLife = 1;
    float lives;
    TextMeshProUGUI livesText;

    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();

    }

    private void UpdateDisplay()
    {
        if (lives <= 0)
        {
            livesText.text = "0";
            return;
        }
        livesText.text = lives.ToString();
    }


    public void TakeLife()
    {

        lives -= damageLife;
        UpdateDisplay();
        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }

    }

}
