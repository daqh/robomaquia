using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof (HealthController))]
public class CharacterMessageSystem : MonoBehaviour
{
    [SerializeField]
    private DamageTextMeshProMessage damagePopup;

    private HealthController healthController;

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
    }

    private void OnEnable()
    {
        healthController.OnGetDamage += OnGetDamage;
    }

    private void OnDisable()
    {
        healthController.OnGetDamage -= OnGetDamage;
    }

    private void OnGetDamage(Damage damage)
    {
        int amount = damage.Amount;
        int referenceAmount = damage.ReferenceAmount;
        int delta = amount - referenceAmount;
        GameObject o = Instantiate(damagePopup.Popup.gameObject, transform.position, Quaternion.identity);
        o.name = $"Damage Popup x {amount} {gameObject.name}";
        TextMeshPro textMeshPro = o.GetComponent<TextMeshPro>();
        DamagePopup popup = o.GetComponent<DamagePopup>();
        popup.LifeTime += ((float)delta / referenceAmount)/20f;
        textMeshPro.SetText(amount.ToString());
        textMeshPro.color = Color.Lerp(Color.Lerp(Color.white, Color.yellow, (float)delta/(referenceAmount / 2)), Color.red, (float)delta/(referenceAmount));
        textMeshPro.fontSize += ((float)delta / referenceAmount) * damagePopup.FontSizeFactor;
    }

}

[Serializable]
class TextMeshProMessage {

    [SerializeField]
    private TextMeshPro popup;

    public TextMeshPro Popup {
        get {
            return popup;
        }
    }
}

[Serializable]
class DamageTextMeshProMessage : TextMeshProMessage {

    [SerializeField]
    [Range(0, 2)]
    private float fontSizeFactor = 1;

    public float FontSizeFactor {
        get {
            return fontSizeFactor;
        }
    }

}
