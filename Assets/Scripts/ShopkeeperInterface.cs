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
    private int healthUpgradeCost = 40; // Cost for upgrading health
    private int damageUpgradeCost = 50; // Cost for upgrading damage
    private int speedUpgradeCost = 35; // Cost for upgrading speed
    private int luckUpgradeCost = 90; // Cost for upgrading luck
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
    }

    private void ToggleShop()
    {
        print ("Shop is Open");
        shopUi.SetActive(true);
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
}