using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopPanel : MonoBehaviour
{
    public TextMeshProUGUI gemText;
    public GameObject player;
    public TextMeshProUGUI textBox;
    public Button buyButton;
    public string[] descriptions;
    public int[] prices;
    private int current;
    public FloatVariable MaxHP, Damage, AtkSpd, Move;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0; 
    }

    public void ChangeOption(int i)
    {
        current = i;
        textBox.text = descriptions[i] + '\n' + "Cost: " + prices[i];
        if(i > 0 && prices[i] < Gem.Gems)
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }
    }

    public void BuySelection()
    {
        Gem.Gems -= prices[current];
        if (current == 1)
        {
            MaxHP.Value += 10;
        }
        else if (current == 2)
        {
            Damage.Value += 5;
        }
        else if (current == 3)
        {
            AtkSpd.Value += .25f;
        }
        else if (current == 4)
        {
            Move.Value += 7;
        }
    }
    public void  DoneShopping()
    {
        Time.timeScale = 1;
        player.GetComponent<PlayerController>().FinalizeShop();
        gameObject.SetActive(false);
        GameManager.Instance.SaveGems();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void onGUI()
    {
        gemText.text = "Gems: " + Gem.Gems;
    }
}
