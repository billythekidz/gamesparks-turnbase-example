using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Animates player user names shown in gameplay UI depending on current player piece type.
/// </summary>
public class UserName : MonoBehaviour
{
    private const string IsCurrentAnimatorParameterName = "IsCurrent";

    [SerializeField]
    private PieceType correspondingPieceType;

    private string userName;
    private Animator animator;
    private Text text;

    void Awake()
    {
        animator = GetComponent<Animator>();
        text = GetComponentInChildren<Text>();
        userName = correspondingPieceType == PieceType.Heart ? ChallengeManager.Instance.HeartsPlayerName : ChallengeManager.Instance.SkullsPlayerName;
        text.text = userName;
    }

    void Update()
    {
        bool isCurrent = userName == ChallengeManager.Instance.CurrentPlayerName;
        animator.SetBool(IsCurrentAnimatorParameterName, isCurrent);
    }
}