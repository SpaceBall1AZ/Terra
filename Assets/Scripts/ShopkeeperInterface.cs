using UnityEngine;
using TMPro;

public class ShopkeeperInterface : MonoBehaviour
{
    public GameObject shopkeeperUi;
    public GameObject shopUi;
    public float distanceToPlayer;
    private bool shopIsOpen = false;
    [SerializeField] private TMP_Text text;
    [SerializeField] PlayerMove player;
    [SerializeField] private TMP_Text rocks;
    [SerializeField] private TMP_Text coins;
    private int healthUpgradeCost = 40; // Cost for upgrading health
    private int damageUpgradeCost = 50; // Cost for upgrading damage
    private int speedUpgradeCost = 35; // Cost for upgrading speed
    private int luckUpgradeCost = 90; // Cost for upgrading luck
    private int valuableSellingPrice = 50; // Price for selling valuable items
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shopkeeperUi.SetActive(false); 
        shopUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.gameObject.transform.position);
        if (distance <= distanceToPlayer && !shopIsOpen)
        {
            shopkeeperUi.SetActive(true);
            shopIsOpen = true;
            text.enabled = true;
        }
        else if (distance > distanceToPlayer && shopIsOpen)
        {
            shopkeeperUi.SetActive(false);
            shopUi.SetActive(false);
            shopIsOpen = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleShop();
            text.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && !shopIsOpen)
        {
            shopUi.SetActive(false);
        }
        updateRocksText();
        updateCoinsText();
    }

    private void ToggleShop()
    {
        print ("Shop is Open");
        shopUi.SetActive(true);
        updateRocksText();
        updateCoinsText();
    }
    private void updateRocksText()
    {
        rocks.text = "Rocks: " + player.valuables.ToString();
    }
    private void updateCoinsText()
    {
        coins.text = "Coins: " + player.coins.ToString();
    }
    public void UpgradeHealth()
    {
        if (player.coins >= healthUpgradeCost)
        {
            player.coins -= healthUpgradeCost;
            player.health += 20; // Increase max health by 20
            Debug.Log("Health upgraded! New max health: " + player.health);
        }
        else
        {
            Debug.Log("Not enough coins to upgrade health.");
        }                                   
    }
    public void UpgradeDamage()
    {
        if (player.coins >= damageUpgradeCost)
        {
            player.coins -= damageUpgradeCost;
            player.damage += 5; // Increase damage by 5
            Debug.Log("Damage upgraded! New damage: " + player.damage);
        }
        else
        {
            Debug.Log("Not enough coins to upgrade damage.");
        }
    }
    public void UpgradeSpeed()
    {
        if (player.coins >= speedUpgradeCost)
        {
            player.coins -= speedUpgradeCost;
            player.speed += 2; // Increase speed by 2
            Debug.Log("Speed upgraded! New speed: " + player.speed);
        }
        else
        {
            Debug.Log("Not enough coins to upgrade speed.");
        }
    }
    public void UpgradeLuck()
    {
        if (player.coins >= luckUpgradeCost)
        {
            player.coins -= luckUpgradeCost;
            player.luck += 1; // Increase luck by 1
            Debug.Log("Luck upgraded! New luck: " + player.luck);
        }
        else
        {
            Debug.Log("Not enough coins to upgrade luck.");
        }
    }
    public void SellValuable()
    {
        if (player.valuables > 0)
        {
            player.coins += valuableSellingPrice;
            player.valuables -= 1; // Remove one valuable item from the player's inventory
            Debug.Log("Valuable item sold! Coins earned: " + valuableSellingPrice);
        }
        else
        {
            Debug.Log("No valuable item to sell.");
        }
    }

}