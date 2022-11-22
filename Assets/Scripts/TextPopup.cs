using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPopup : MonoBehaviour
{

    private TextMeshPro textMeshPro;

    private float timer = 0.2f;

    private Color textColor;

    private float speed = 1;

    void Awake() {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    void Start() {
        textColor = textMeshPro.color;
    }

    void Update() {
        timer -= Time.deltaTime;
        if(timer < 0) {
            textColor.a -= Time.deltaTime * speed * 3;
            textMeshPro.color = textColor;
            if(textColor.a < 0) {
                Destroy(gameObject);
            }
            transform.position += transform.up * Time.deltaTime * speed;
        } else {
            transform.position += transform.up * Time.deltaTime * speed / 2;
        }
    }

    public void SetText(string text) {
        textMeshPro.SetText(text);
    }

    public void SetFontSize(float fontSize) {
        textMeshPro.fontSize = fontSize;
    }

    public void SetSpeed(float speed) {
        this.speed = speed;
    }

    public void SetColor(Color color) {
        textMeshPro.color = color;
    }

}
