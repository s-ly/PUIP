/* Скрипт управления камерой CamControl v.1.0.
Скрип вешается на дополнительную цель, к которой потомок камера.
Цель в центре вращения. в публичную ссылку кладём камеру.
Есть проблемы с рывками, скорее всего из-за использования методов трансформации.
Интересный урок про повороты: https://www.youtube.com/watch?v=7VWV4dr9qCo */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    float MousePosX;
    float MousePosY;
    float MouseScroll;

    public Transform Cam;
    public float MouseSpeed = 1f; //400
    public float CamScrollSpeed = 1f; //150
    public float FactorShift = 0.001f; // ккоэффициент скорости смещения

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) MouseRot();
        if (Input.GetAxis("Mouse ScrollWheel")!=0) CamScroll();
        if (Input.GetMouseButton(2)) Shift(); // если нажато колёсико
    }

    public void MouseRot()
    {
        MousePosX = Input.GetAxis("Mouse X") * MouseSpeed;
        MousePosY = Input.GetAxis("Mouse Y") * MouseSpeed;
        this.transform.Rotate(0f, MousePosX * Time.deltaTime, 0f, Space.World);
        this.transform.Rotate(-MousePosY * Time.deltaTime, 0f, 0f, Space.Self);
    }

    public void CamScroll()
    {
        MouseScroll = Input.GetAxis("Mouse ScrollWheel") * CamScrollSpeed;
        Cam.transform.Translate(Vector3.forward * MouseScroll * Time.deltaTime, Space.Self);
    }

    public void Shift()
    {
        // обновление координат курсора
        MousePosX = Input.GetAxis("Mouse X") * MouseSpeed;
        MousePosY = Input.GetAxis("Mouse Y") * MouseSpeed;

        // локальный сдвиг опорной точки
        this.transform.Translate(Vector3.right * Time.deltaTime * MousePosX * -FactorShift, Space.Self); // смещение опорной точки
        this.transform.Translate(Vector3.up * Time.deltaTime * MousePosY * -FactorShift, Space.Self); // смещение опорной точки

    }
}
