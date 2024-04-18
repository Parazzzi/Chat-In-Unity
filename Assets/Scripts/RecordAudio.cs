using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordAudio : MonoBehaviour
{
    [SerializeField] private ChatManager chatManager;
    [SerializeField] Button voiceInputButton;
    [SerializeField] private Image buttonImage;

    [Header("Record Image")]
    [SerializeField] private Sprite recordOffImage;
    [SerializeField] private Sprite recordOnImage;

    private AudioClip recordedAudio;
    private bool isRecording = false;

    private void Awake()
    {
        buttonImage.sprite = recordOffImage;
    }

    public void ToggleRecording()
    {
        isRecording = !isRecording;

        if (isRecording)
            StartRecording();
        else
            StopRecording();
    }

    private void StartRecording()
    {
        recordedAudio = Microphone.Start(null, true, 60, 44100);
        buttonImage.sprite = recordOnImage;
    }

    private void StopRecording()
    {
        Microphone.End(null);
        chatManager.SendAudioChatMessage(recordedAudio, chatManager.GetPlayerName());
        buttonImage.sprite = recordOffImage;
        recordedAudio = null;
    }

}
