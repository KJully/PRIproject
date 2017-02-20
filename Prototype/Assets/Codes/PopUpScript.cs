using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUpScript : MonoBehaviour {

    private static GameObject popUp;
    private static GameObject popUpText;
    private static readonly float FADE_DELAY = 0.6f;
    private static readonly float FADE_DURATION = 0.4f;

	void Start () {
        popUp = GameObject.Find("popUp");
        popUpText = GameObject.Find("popUpText");
        gameObject.SetActive(false);
    }
	
	void Update () {
	
	}

    IEnumerator Fade() {
        yield return new WaitForSeconds(FADE_DELAY);

        for (float f = FADE_DURATION; f >= 0; f -= 0.03f) {
            Color colorPopup = GetComponent<Image>().color;
            colorPopup.a = f / FADE_DURATION;
            GetComponent<Image>().color = colorPopup;

            Color colorText = popUpText.GetComponent<Text>().color;
            colorText.a = f / FADE_DURATION;
            popUpText.GetComponent<Text>().color = colorText;
            yield return new WaitForSeconds(0.03f);
        }
        gameObject.SetActive(false);
    }

    public void showPopUp(Color color, string text) {
        StopCoroutine("Fade");
        GetComponent<Image>().color = color;
        popUpText.GetComponent<Text>().color = Color.black;
        popUpText.GetComponent<Text>().text = text;
        gameObject.SetActive(true);
        StartCoroutine("Fade");
    }

    public static GameObject getPopup() {
        return popUp;
    }
}
