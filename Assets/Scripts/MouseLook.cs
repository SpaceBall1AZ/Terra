using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSpeed = 100f; // скорость вращения камеры

    public Transform playerBody; // компонент transform для персонажа и поворота тела
    float rotationY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // блокируем курсор мышки для экрана
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime; // считываем движение мышки по горизонтали
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime; // считываем движение мышки по вертикали

        rotationY -= mouseY; // сохраняем значение угла поворота по вертикали
        rotationY = Mathf.Clamp(rotationY, -45f, 45f); // ограничиваем движение камеры по вертикали

        transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f); // поворачиваем камеру по вертикали (вокруг оси x)

        playerBody.Rotate(Vector3.up * mouseX); // поворачиваем персонажа по гооризонтали

    }
    void OnGUI() // Простой прицел
    {
        int size = 24;
        float posX = GetComponent<Camera>().pixelWidth / 2 - size / 4;
        float posY = GetComponent<Camera>().pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }
}
