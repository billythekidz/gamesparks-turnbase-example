using GameSparks.Api.Messages;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles matchmaking.
/// </summary>
public class MainMenuPanel : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    void Awake()
    {
        playButton.onClick.AddListener(Play);
        MatchNotFoundMessage.Listener += OnMatchNotFound;
        ChallengeStartedMessage.Listener += OnChallengeStarted;
    }

    void OnDestroy()
    {
        ChallengeStartedMessage.Listener -= OnChallengeStarted;
    }

    private void Play()
    {
        BlockInput();
        MatchmakingRequest request = new MatchmakingRequest();
        request.SetMatchShortCode("DefaultMatch");
        request.SetSkill(0);
        request.Send(OnMatchmakingSuccess, OnMatchmakingError);
    }

    private void OnMatchmakingSuccess(MatchmakingResponse response)
    {
    }

    private void OnMatchmakingError(MatchmakingResponse response)
    {
        UnblockInput();
    }

    private void OnMatchNotFound(MatchNotFoundMessage message)
    {
        UnblockInput();
    }

    private void OnChallengeStarted(ChallengeStartedMessage message)
    {
        LoadingManager.Instance.LoadNextScene();
    }

    private void BlockInput()
    {
        playButton.interactable = false;
    }

    private void UnblockInput()
    {
        playButton.interactable = true;
    }
}