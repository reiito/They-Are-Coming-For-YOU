using UnityEngine;

public class Debugger : MonoBehaviour
{
    public static void d_Message(string message)
    {
        Debug.Log("[DEBUG] " + message);
    }

    public static void d_Error(string message)
    {
        Debug.Log("[ERROR] " + message);
    }

    public static void d_ButtonPressed(string buttonName)
    {
        Debug.Log("[DEBUG] '" + buttonName + "' pressed.");
    }

}
