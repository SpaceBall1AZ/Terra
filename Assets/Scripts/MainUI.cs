using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUI : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Slider healthSlider;
    public float damageRate = 3f; // Rate at which health decreases per second when being damaged
    private PlayerMove playerMove;
    private float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void SliderUpdate()
    {
        healthSlider.value = playerMove.health;
        healthText.text = playerMove.health.ToString();
    }
    public void TakeDamage(int damage)
    {
        playerMove.health -= damage;
        if (playerMove.health < 0)
        {
            playerMove.health = 0;
        }
        SliderUpdate();
    }
    public void damageCheck()
    {
        if (true)
        {
            TakeDamage((int)(damageRate * Time.deltaTime));
        }

        else
        {
            // If not taking damage, you can implement logic to stop health decrease or other actions
        }
    }
}
