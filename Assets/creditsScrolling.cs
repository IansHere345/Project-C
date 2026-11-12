using UnityEngine;

public class creditsScrolling : MonoBehaviour
{
    public float scrollSpeed = 40f;
    private RectTransform rectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
    }
}
//Source Used: https://www.youtube.com/watch?v=Eeee4TU69x4