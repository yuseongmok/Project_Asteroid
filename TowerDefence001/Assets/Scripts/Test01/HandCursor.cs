using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCursor : MonoBehaviour
{

    [SerializeField] Texture2D cursorHand;
  
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorHand, Vector2.zero, CursorMode.ForceSoftware);
    }

  
}
