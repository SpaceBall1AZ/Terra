using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    CharacterController controller;

    public int health = 100; // Текущее здоровье игрока
    public int coins = 100; // количество денег игрока
    public int luck = 0; // удача игрока
    public int damage = 10; // урон игрока
    public float speed = 10f; // скорость персонажа
    public float gravity = -9.81f; // гравитация для падения
    public float jump = 3;

    public Vector3 velocity; // вектор падения

    public Transform groundPoint; // центр сферы, которая будет проверять стоим ли мы на земле
    public float groundDistance = 0.9f; //  радиус сферы, которая будет проверять стоим ли мы на земле
    public LayerMask groundMask; // слой для земли и других объектов

    bool isGround; // переменная, которая отвечает, стоим ли мы на земле или нет

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Проверяем расстояние до объектов groundMask по сфере вокруг позиции groundPoint по радиусу groundDistance 
        isGround = Physics.CheckSphere(groundPoint.position, groundDistance, groundMask);

        if (isGround && velocity.y < 0) // если мы стоим на земле
        {
            velocity.y = -2f; // задаем вектор падения
        }

        float x = Input.GetAxis("Horizontal"); // считываем движение по оси X
        float z = Input.GetAxis("Vertical"); // считываем движение по оси Z

        Vector3 move = transform.right * x + transform.forward * z; // задаем вектор направления

        velocity.y += gravity * Time.deltaTime; // увеличиваем вектор падения

        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }



        controller.Move(move * speed * Time.deltaTime); // производим движение
        controller.Move(velocity * Time.deltaTime); // падаем(на нас постоянно действует гравитация)
    }
}
