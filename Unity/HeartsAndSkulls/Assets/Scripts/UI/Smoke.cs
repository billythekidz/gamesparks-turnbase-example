using UnityEngine;

/// <summary>
/// Enables or disables smoke particles corresponding to current player piece type.
/// </summary>
public class Smoke : MonoBehaviour
{
    [SerializeField]
    private PieceType correspondingPieceType;

    private ParticleSystem particles;

    void Awake()
    {
        particles = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        PieceType currentPlayerPieceType = ChallengeManager.Instance.CurrentPlayerPieceType;
        particles.gameObject.SetActive(currentPlayerPieceType == PieceType.Empty || currentPlayerPieceType == correspondingPieceType);
    }
}