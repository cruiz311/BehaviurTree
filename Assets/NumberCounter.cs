using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum tipo
{
    policia,
    zombie,
    civil
}

public class NumberCounter : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public int number = 0;
    public tipo tipo;

    private void Update()
    {
        switch (tipo)
        {
            case tipo.policia:
                GameManager.Instance.numerosPolicia = number;
                break;
            case tipo.zombie:
                GameManager.Instance.numerosZombie = number;
                break;
            case tipo.civil:
                GameManager.Instance.numerosCivil = number;
                break;
        }
    }
    public void IncrementNumber()
    {
        if (number < 9)
        {
            number++;
            UpdateText();
        }
    }

    // Método para decrementar el número
    public void DecrementNumber()
    {
        if (number > 0)
        {
            number--;
            UpdateText();
        }
    }

    // Método para actualizar el texto en la UI
    private void UpdateText()
    {
        numberText.text = number.ToString();
    }
}

