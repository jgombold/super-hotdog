using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockMouse : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
