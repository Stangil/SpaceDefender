using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthDisplay : MonoBehaviour
{
    TextMeshProUGUI playerHealthText;
    void Start()
    {
        playerHealthText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        playerHealthText.text = FindObjectOfType<GameSession>().GetPlayerHealth().ToString();
    }
}
