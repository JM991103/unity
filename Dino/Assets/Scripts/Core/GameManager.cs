using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    Player player;
    ScorePanel scorePanel;

    int score;
    int hiScore;

    public int Score { get => score; set => score = value; }


    public Player Player { get => player; }

    protected override void Initialize()
    {
        player = FindObjectOfType<Player>();
        scorePanel = FindObjectOfType<ScorePanel>();

        Load();
    }

    public void Save()
    {
        SaveData savedata = new();          // SaveData��� Ŭ����Ÿ���� ���� savedata�� ����� �ְ� new Ű���带 ����� �ν��Ͻ�ȭ ���ش�.
                                            // (SaveData��) MonoBehaviour�� ���� [Serializable]�� ����� ����ȭ �����ش�. ex) json ��밡��

        if (Score > scorePanel.HiScore)
        {
            savedata.bestScore = Score;         // savedata�� �ִ� bsetScore ������ Score ���� �־��ش�.


            string saveDataJson = JsonUtility.ToJson(savedata);     // ���ڿ� Ÿ������ saveDataJson������ savedata�� json���·� ��ȯ�� �����Ѵ�.

            string path = $"{Application.dataPath}/Save/";          // path������ ���� ������ ��� + ���ο� ���� ������ ��θ� �����Ѵ�.
            if (!Directory.Exists(path))    // ���� �ش� ��ο� ������ ������
            {
                Directory.CreateDirectory(path);    // �� ��ο� ������ �ϳ� ������
            }
            string fullPath = $"{path}Save.json";   // fullPath ������ path��ο� �̸�.josn������ ����Ų��.
            File.WriteAllText(fullPath, saveDataJson);  // ������ ��ο� �ִ� json������ ���Ͽ� saveDataJson(json���·� ��ȯ�Ѱ�)�� �����Ѵ�.
        }
    }

    void Load()
    {
        string path = $"{Application.dataPath}/Save/";  // ��� Ȯ�ο�
        string fullPath = $"{path}Save.json";           // ��ü ��� Ȯ�ο�
        if (Directory.Exists(path) && File.Exists(fullPath))    // �ش� ������ �ְ�, ���ϵ� ������
        {
            string json = File.ReadAllText(fullPath);   // Json������ ������ �б�
            SaveData loadData = JsonUtility.FromJson<SaveData>(json);
            scorePanel.HiScore = loadData.bestScore;   // �о�� �����ͷ� �ְ����� ��� ����
        }
    }
}
