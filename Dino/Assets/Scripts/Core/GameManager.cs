using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    Player player;

    int score;
    int hiScore;

    public int Score { get => score; set => score = value; }
    public int HiScore { get => hiScore; }


    public Player Player { get => player; }

    protected override void Initialize()
    {
        player = FindObjectOfType<Player>();
    }

    public void Save()
    {
        SaveData savedata = new();          // SaveData��� Ŭ����Ÿ���� ���� savedata�� ����� �ְ� new Ű���带 ����� �ν��Ͻ�ȭ ���ش�.
                                            // (SaveData��) MonoBehaviour�� ���� [Serializable]�� ����� ����ȭ �����ش�. ex) json ��밡��

        savedata.bestScore = Score;         // savedata�� �ִ� bsetScore ������ Score ���� �־��ش�.

        string saveDataJson = JsonUtility.ToJson(savedata);     // ���ڿ� Ÿ������ saveDataJson������ savedata�� json���·� ��ȯ�� �����Ѵ�.

        string path = $"{Application.dataPath}/Save/";          // path������ ���� ������ ��� + ���ο� ���� ������ ��θ� �����Ѵ�.
        if (!Directory.Exists(path))    // ���� �ش� ��ο� ������ ������
        {
            Directory.CreateDirectory(path);    // �� ��ο� ������ �ϳ� ������
        }
        string pullPath = $"{path}Save.json";   // pullPath ������ path��ο� �̸�.josn������ ����Ų��.
        File.WriteAllText(pullPath, saveDataJson);  // ������ ��ο� �ִ� json������ ���Ͽ� saveDataJson(json���·� ��ȯ�Ѱ�)�� �����Ѵ�.
    }

    void Load()
    {
        string path = $"{Application.dataPath}/Save/";
        string pullPath = $"{path}Save.json";
        if (!Directory.Exists(path))
        {

        }
    }
}
