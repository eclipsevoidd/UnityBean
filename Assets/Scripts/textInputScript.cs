using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class textInputScript : MonoBehaviour
{
    private string text;
    private string[] input = {"Sveiks", "Jauku dienu", "Prieks Tevi redzēt", "Uzredzēšanos",
        "Jauki, ka atnāci", "Tiksimiers rīt"};
    private int rand;

    public GameObject inputField;
    public GameObject textField;
    public GameObject reverseTextToggle;

    public void getText()
    {
        rand = Random.Range(0, input.Length); // ģenerē nejaušu skaitli intervālā 0 - 6 (neieskaitot)
        text = inputField.GetComponent<TMP_InputField>().text;

        if (text.Equals("Intars"))
        {
            textField.GetComponent<TMP_Text>().text = "STUPID NIGGER!";
            return;
        }

        textField.GetComponent<TMP_Text>().text = input[rand] + " " + text + "!";

        reverseTextToggle.GetComponent<Toggle>().interactable = true;
        if (reverseTextToggle.GetComponent<Toggle>().isOn)
        {
            ReverseText();
        }
    }

    public void ReverseText()
    {
        char[] charArray = textField.GetComponent<TMP_Text>().text.ToCharArray();
        System.Array.Reverse(charArray);
        textField.GetComponent<TMP_Text>().text = new string(charArray);

    }

}
