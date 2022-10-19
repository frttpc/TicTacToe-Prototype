using UnityEngine;
using TMPro;

public class PlayedPiece : MonoBehaviour
{
    public TextMeshPro valueText;
    public SpriteRenderer spriteRenderer;

    public void setValueText(int value)
    {
        valueText.text = value.ToString();
    }

    public void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }
}
