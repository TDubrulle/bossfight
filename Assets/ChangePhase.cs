using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangePhase : MonoBehaviour
{
    public Image image;
    private bool firstPhase = false;
    private bool secondPhase = false;

    void hitAlduinFirstTime()
    {
        this.gameObject.GetComponentInParent<Gliding>().secondStep = true;
        firstPhase = true;
    }
    void hitAlduinSecondTime()
    {
        this.gameObject.GetComponentInParent<Gliding>().secondStep = true;
    }

    void Update()
    {
        if(firstPhase)
        {
            if (image.color.a > 255) return;

            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + 0.1f);
            if(image.color.a >= 255)
            {
                firstPhase = false;
                secondPhase = true;
            }
        }
        if (secondPhase)
        {
            if (image.color.a < 0) return;
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - 1);
            if (image.color.a <= 0)
            {
                secondPhase = false;
            }
        }
    }
}
