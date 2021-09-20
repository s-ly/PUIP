// Скрипт перемещения объекта к цели

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Transform selectTarget; // какая цель выбрана

    // цели для кнопок
    public Transform target_1;
    public Transform target_2;
    public Transform target_3;
    public Transform target_4;

    public float speed = 0.1f; // скорость перемещения к цели
    private float X, Y, Z; // разница между положением объекта и цели
    private float stop = 0.01f; // растояние, после которого двигать объект уже не нужно

    private void Start()
    {
        selectTarget = target_1;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTarget(selectTarget);
    }

    // Осуществляет перемещение к выбранной цели
    public void MoveTarget(Transform target)
    {
        //вычисляем разницу между положением объекта и цели
        X = transform.position.x - target.position.x;
        Y = transform.position.y - target.position.y;
        Z = transform.position.z - target.position.z;
        X = Mathf.Abs(X); // модуль числа    
        Y = Mathf.Abs(Y); // модуль числа  
        Z = Mathf.Abs(Z); // модуль числа  

        // пока хотябы одна координата не приблизилась к цели достаточно близко выполнять
        if (X > stop || Y > stop || Z > stop)
        {
            // плавно совмещаем координаты объекта и цели
            transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
            Debug.Log(X);
            Debug.Log(Y);
            Debug.Log(Z);
        }
        else
        {
            // растояние меньше значения "stop" (двигать не надо)
            Debug.Log("stop");
        }
    }

    // действия для 4-х кнопок
    public void SelectTraget_1() {selectTarget = target_1;}
    public void SelectTraget_2() {selectTarget = target_2;}
    public void SelectTraget_3() {selectTarget = target_3;}
    public void SelectTraget_4() {selectTarget = target_4;}
}
