using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class SaveHighScore : MonoBehaviour
{
    [SerializeField]
    private int characterLimit = 3;

    [SerializeField]
    private InputField inputField;

    [SerializeField]
    private Text box1;

    [SerializeField]
    private Text box2;

    [SerializeField]
    private Text box3;

    [SerializeField]
    private Text box4;

    [SerializeField]
    private Text box5;

    //public static SaveHighScore highScore;

    public static HighScoreList thisList = new HighScoreList();

    private static string name;
    private static float time;

    private void Start()
    {
        inputField.characterLimit = characterLimit;
    }

    public void UpdateData()
    {
        SetInitialScores();
        Load();
        time = GameTimer.gameTime;
        name = inputField.text.ToUpper();
        if(name == string.Empty)
        {
            name = "000".ToString() ;
        }
        CheckScores();
        Save();
        SetTextBoxes();
    }

    private void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
            + "/highscores.dat");

        HighScoreList savingList = new HighScoreList();
        savingList = thisList;

        bf.Serialize(file, savingList);
        file.Close();
    }

    private void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/highscores.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath 
                + "/highscores.dat", FileMode.Open);
            HighScoreList savedList = (HighScoreList)bf.Deserialize(file);
            file.Close();

            thisList = savedList;
        }
    }

    private void SetTextBoxes()
    {
        box1.text = ("1: " + thisList.highScores[0].playerName
            + " - " + thisList.highScores[0].playerTime).ToString();

        box2.text = ("2: " + thisList.highScores[1].playerName
            + " - " + thisList.highScores[1].playerTime).ToString();

        box3.text = ("3: " + thisList.highScores[2].playerName
            + " - " + thisList.highScores[2].playerTime).ToString();

        box4.text = ("4: " + thisList.highScores[3].playerName
            + " - " + thisList.highScores[3].playerTime).ToString();

        box5.text = ("5: " + thisList.highScores[4].playerName
            + " - " + thisList.highScores[4].playerTime).ToString();
    }

    private bool CheckScores()
    {
        for(int i = 0; i < thisList.highScores.Count; i++ )
        {
            //Debug.Log(thisList.highScores.Count);
            if (time < thisList.highScores[i].playerTime)
            {
                thisList.highScores[i].playerTime = time;
                thisList.highScores[i].playerName = name;
                //Debug.Log("Score Updated");
                return true;
            }
        }

        return false;
    }

    private void SetInitialScores()
    {
        thisList = new HighScoreList();
        thisList.highScores = new List<PlayerData>();
        for(int i = 0; i < 5; i++)
        {
            PlayerData pd = new PlayerData();
            thisList.highScores.Add(pd);
            thisList.highScores[i].playerName = "BMW";
            thisList.highScores[i].playerTime = 999.9f;
        }
    }

}
[Serializable]
public class HighScoreList
{
    public List<PlayerData> highScores = new List<PlayerData>();
}

[Serializable]
public class PlayerData
{
    public string playerName;
    public float playerTime;
}

