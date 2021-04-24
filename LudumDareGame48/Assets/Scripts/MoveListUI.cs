using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveListUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;
    public GameObject image7;
    public GameObject image8;
    public GameObject image9;
    public GameObject image10;


    public Sprite upArrow;
    public Sprite downArrow;
    public Sprite leftArrow;
    public Sprite rightArrow;
    List<GameObject> imagesArray;
    void Start()
    {
        imagesArray = new List<GameObject>();
        imagesArray.Add(image1);
        imagesArray.Add(image2);
        imagesArray.Add(image3);
        imagesArray.Add(image4);
        imagesArray.Add(image5);
        imagesArray.Add(image6);
        imagesArray.Add(image7);
        imagesArray.Add(image8);
        imagesArray.Add(image9);
        imagesArray.Add(image10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveListUIHandler(List<Vector2> inputArray, int currentIndex) {
        for (int i = 0; i < inputArray.Count; i++) {
            if (inputArray[i].x == 1f) {
                imagesArray[i].GetComponent<Image>().sprite = rightArrow;
            }
            else if (inputArray[i].x == -1f) {
                imagesArray[i].GetComponent<Image>().sprite = leftArrow;
            }
            else if (inputArray[i].y == 1f) {
                imagesArray[i].GetComponent<Image>().sprite = upArrow;
            }
            else if (inputArray[i].y == -1f) {
                imagesArray[i].GetComponent<Image>().sprite = downArrow;
            }

            if (i == currentIndex) {
                imagesArray[i].GetComponent<Image>().color = Color.gray;
            }
            else {
                imagesArray[i].GetComponent<Image>().color = Color.white;
            }
        }
    }
}
