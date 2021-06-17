using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseStuff : MonoBehaviour
{

    public static bool isCursorVisible;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isCursorVisible = !isCursorVisible;

            if(isCursorVisible == true)
            {
                MouseVisible();
            }

            if(isCursorVisible == false)
            {
                MouseInvisible();
            }
        }
    }



    public static void MouseVisible()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public static void MouseInvisible()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }




}
