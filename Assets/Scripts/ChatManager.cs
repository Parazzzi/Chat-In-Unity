using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;


public class ChatManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    [Header("Message Prefabs")]
    [SerializeField] private Message chatMessagePrefab;
    [SerializeField] private Message AudioMessagePrefab;

    [SerializeField] private GameObject chatContent;
    [SerializeField] private TMP_InputField chatInput;
    [SerializeField] private Scrollbar scrollbar;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!string.IsNullOrWhiteSpace(chatInput.text))
            {
                SendChatMessage(chatInput.text, GetPlayerName());
                chatInput.text = "";
                UpdateScrollbar();
            }
        }
        UpdateInputField();
    }

    public string GetPlayerName()
    {
        return playerData.playerName;
    }

    private void SendChatMessage(string _message, string _fromWho = null)
    {
        if (string.IsNullOrWhiteSpace(_message)) return;

        AddTextMessage(chatMessagePrefab, CreateMessage(_fromWho, _message));
    }

    public void SendAudioChatMessage(AudioClip _audioClip, string _fromWho = null)
    {
        if (_audioClip == null) return;

        AddAudioMessage(AudioMessagePrefab, CreateMessage(_fromWho, "(Audio Message)"), _audioClip);
    }

    private string CreateMessage(string _fromWho, string messageText)
    {
        return $"[{GetCurrentTime()}] {_fromWho}: {messageText}";
    }

    private string GetCurrentTime()
    {
        return "<color=blue>" + DateTime.Now.ToString("HH:mm") + "</color>";
    }

    private void AddTextMessage(Message prefab, string msg)
    {
        TextMessage TM = Instantiate(prefab, chatContent.transform) as TextMessage;
        TM.SetText(msg);
        UpdateScrollbar();
    }

    private void AddAudioMessage(Message prefab, string msg, AudioClip audioClip)
    {
        AudioMessage AM = Instantiate(prefab, chatContent.transform) as AudioMessage;
        AM.SetText(msg);
        AM.SetAudio(audioClip);
        UpdateScrollbar();
    }

    private void UpdateScrollbar()
    {
        scrollbar.value = 0;
    }

    private void UpdateInputField()
    {
        chatInput.Select();
        chatInput.ActivateInputField();
    }
}
