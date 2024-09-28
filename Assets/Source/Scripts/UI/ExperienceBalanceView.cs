using System.Text;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ExperienceBalanceView : MonoBehaviour
{
    private readonly string Postfix = "EXP";
    
    [SerializeField] private ExperienceBalance _experienceBalance;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _experienceBalance.Changed += OnChanged;
        _text.text =  $"{_experienceBalance.Balance} {Postfix}";
    }

    private void OnDestroy() =>
        _experienceBalance.Changed -= OnChanged;

    private void OnChanged() =>
        _text.text = $"{_experienceBalance.Balance} {Postfix}";
}
