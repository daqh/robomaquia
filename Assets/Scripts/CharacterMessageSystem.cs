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

    private void OnGetDamage(int amount)
    {
        GameObject o = Instantiate(damagePopup.Popup.gameObject, transform.position, Quaternion.identity);
        o.name = $"Damage Popup x {amount} {gameObject.name}";
        TextMeshPro textMeshPro = o.GetComponent<TextMeshPro>();
        DamagePopup popup = o.GetComponent<DamagePopup>();
        popup.LifeTime += ((float)amount / healthController.MaxHealth);
        textMeshPro.SetText(amount.ToString());
        textMeshPro.color = Color.Lerp(Color.Lerp(Color.white, Color.yellow, (float)amount/(healthController.MaxHealth / 2)), Color.red, (float)amount/(healthController.MaxHealth));
        textMeshPro.fontSize += ((float)amount / healthController.MaxHealth) * damagePopup.FontSizeFactor;
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
