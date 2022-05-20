using UnityEngine;
using UnityEngine.UI;

public class ButtonCommands : MonoBehaviour
{
    public void ResetInteractivity(Button button)
    {
        button.interactable = false;
        button.interactable = true;
    }
}
