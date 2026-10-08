using UnityEngine;

public class ShopkeeperInterface : MonoBehaviour
{
    public GameObject shopkeeperUi;
    public float distanceToPlayer;
    public PlayerMove player;
    private bool shopIsOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shopkeeperUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.gameObject.transform.position);
        if (distance <= distanceToPlayer)
        {
            shopkeeperUi.SetActive(true);
            shopIsOpen = true;
        }
        else
        {
            shopkeeperUi.SetActive(false);
            shopIsOpen = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && shopIsOpen)
        {
            ToggleShop();
        }
    }

    private void ToggleShop()
    {
        print ("Shop is Open");
    }
}
