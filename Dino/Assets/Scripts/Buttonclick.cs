using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttonclick : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(ReStart);
    }

    void ReStart()
    {
        // ���� ���� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
