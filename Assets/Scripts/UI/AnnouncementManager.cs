using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnnouncementManager : MonoBehaviour
{
    public static AnnouncementManager instance { private set; get; }
    private TextMeshProUGUI announcement;
    [SerializeField] private float announcementLength;
    [SerializeField] private float fadingTime;
    private float timer;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        announcement = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        
        if(fadingTime * 2 > announcementLength)
        {
            fadingTime = announcementLength / 2;
        }
    }
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
    public IEnumerator ShowAnnouncement(string message)
    {
        announcement.text = message;
        yield return StartCoroutine(FadeIn(fadingTime));
        yield return new WaitForSeconds(announcementLength - fadingTime * 2);
        yield return StartCoroutine(FadeOut(fadingTime));
    }
    private IEnumerator FadeIn(float duration)
    {
        announcement.color = new Color(announcement.color.r, announcement.color.g, announcement.color.b, 0);
        while(announcement.color.a < 1f)
        {
            announcement.color = new Color(announcement.color.r, announcement.color.g, announcement.color.b, announcement.color.a + Time.deltaTime / duration);
            yield return null;
        }
    }
    private IEnumerator FadeOut(float duration)
    {
        while (announcement.color.a > 0f)
        {
            announcement.color = new Color(announcement.color.r, announcement.color.g, announcement.color.b, announcement.color.a - Time.deltaTime / duration);
            yield return null;
        }
    }
}
