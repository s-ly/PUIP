// Управление Scene_1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_1 : MonoBehaviour
{
    // детали
    public GameObject mesh; // пробка
    public GameObject otherMesh; // другие детали

    public int flagHideMesh = 1;
    public int flagHideOtherMesh = 1;

    // Выход из приложения.
    public void ExitApp()
    {
        Application.Quit();
    }

    // скрыть пробку
    public void HideMeshProbka()
    {
        if (flagHideMesh == 1)
        {
            mesh.SetActive(false);
            flagHideMesh = 0;
        }
        else
        {
            mesh.SetActive(true);
            flagHideMesh = 1;
        }
    }
    // скрыть детали
    public void HideOtherMesh()
    {
        if (flagHideOtherMesh == 1)
        {
            otherMesh.SetActive(false);
            flagHideOtherMesh = 0;
        }
        else
        {
            otherMesh.SetActive(true);
            flagHideOtherMesh = 1;
        }
    }
}
