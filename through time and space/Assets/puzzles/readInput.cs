using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class TMPCharacterTransformer : MonoBehaviour
{
    public TMP_InputField inputField;

    private static char[] qwertyButtons = new char[]
    {
        'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P',
        'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L',
        'Z', 'X', 'C', 'V', 'B', 'N', 'M'
    };

    void Start()
    {
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    void OnInputValueChanged(string input)
    {
        // Start a coroutine to handle the text update
        StartCoroutine(UpdateTextAfterChange(input));
    }

    IEnumerator UpdateTextAfterChange(string input)
    {
        yield return new WaitForEndOfFrame(); // Ensure this happens after the input has been processed

        if (input.Length > 0)
        {
            char lastChar = input[input.Length - 1];
            string transformedChar = TransformCharacter(lastChar);
            string updatedText = input.Substring(0, input.Length - 1) + transformedChar;

            // Temporarily disable the event listener to avoid recursion
            inputField.onValueChanged.RemoveListener(OnInputValueChanged);

            inputField.text = updatedText;
            inputField.caretPosition = updatedText.Length; // Move caret to the end

            // Re-enable the event listener
            inputField.onValueChanged.AddListener(OnInputValueChanged);
        }
    }

    string TransformCharacter(char c)
    {
        int index = Array.IndexOf(qwertyButtons, c);
        if (index != -1)
        {
            // Move forward by 4 positions
            int newIndex = (index + 4) % qwertyButtons.Length;
            return qwertyButtons[newIndex].ToString();
        }
        else
        {
            return c.ToString(); // If character is not found, keep it unchanged
        }
    }
}
