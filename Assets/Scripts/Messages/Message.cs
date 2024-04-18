using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Message : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;

    public void SetText(string str)
    {
        messageText.text = str;
        messageText.ForceMeshUpdate();
    }


}