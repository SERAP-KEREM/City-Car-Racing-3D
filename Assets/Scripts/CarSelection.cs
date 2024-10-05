using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    [Header("Buttons and Canvas")]
    public Button nextButton;
    public Button previousButton;

    [Header("Cameras")]
    public GameObject cam1;
    public GameObject cam2;

    [Header("Buttons and Canvas")]
    public GameObject SelectionCanvas;
    public GameObject PlayButton;
    public GameObject SkipButton;

    private int currentCar;
    private GameObject[] carList;

    private void Awake()
    {
        SelectionCanvas.SetActive(false);
        PlayButton.SetActive(false);  
        cam2.SetActive(false);
        ChooseCar(0);
    }
    private void Start()
    {
        currentCar = PlayerPrefs.GetInt("CarSelected");
        //feeding car models to carList array
        carList =new GameObject[transform.childCount];

        for(int i=0;i<transform.childCount;i++)
        {
            carList[i]=transform.GetChild(i).gameObject;
        }

        //keeping track of currentcar
        foreach(GameObject go in carList)
            go.SetActive(false);

        if (carList[currentCar])
            carList[currentCar].SetActive(true);
    }
    private void ChooseCar(int index)
    {
        previousButton.interactable = (currentCar != 0);
        nextButton.interactable = (currentCar != transform.childCount - 1);

        for(int i=0;i<transform.childCount;i++)
        {
            transform.GetChild(i).gameObject.SetActive(i== index);
        }
    }

    public void SwitchCar(int switchCars)
    {
        currentCar += switchCars;
        ChooseCar(currentCar);
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("CarSelected",currentCar);
        SceneManager.LoadScene("scene_day");
    }

    public void SkipButtonSelected()
    {
        SelectionCanvas.SetActive(true);
        PlayButton.SetActive(true);
        SkipButton.SetActive(false);
        cam1.SetActive(false);
        cam2.SetActive(true);

    }
}
