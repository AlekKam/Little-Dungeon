using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] Text gemsText;
    [SerializeField] Text healthText;

    // Update is called once per frame
    void Update()
    {
        gemsText.text = "Gems: " + GameManager.Instance.getGems();
        healthText.text = "Health: " + GameManager.Instance.GetHealth();
    }
}
