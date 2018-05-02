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

    public static HighScoreData thisList = new HighScoreData();
    private const string saveFileName = "highscores.dat";

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
        time = GameTimer.holdTime;
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
            + "/"+saveFileName);

        HighScoreData highScoreData = new HighScoreData();
        highScoreData.highScores = thisList.highScores;

        bf.Serialize(file, highScoreData);
        file.Close();
    }

    private void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/"+saveFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath 
                + "/" + saveFileName, FileMode.Open);
             HighScoreData highScoreData = new HighScoreData();
            highScoreData = (HighScoreData)bf.Deserialize(file);
            file.Close();

            thisList.highScores = highScoreData.highScores;
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
            if (time < thisList.highScores[i].playerTime)
            {
                if (i + 1 < thisList.highScores.Count)
                {
                    if(i + 2 < thisList.highScores.Count)
                    {
                        if(i + 3 < thisList.highScores.Count)
                        {
                            if( i + 4 < thisList.highScores.Count)
                            {
                                thisList.highScores[i +4].playerTime =
                                    thisList.highScores[i+3].playerTime;
                                thisList.highScores[i + 4].playerName =
                                    thisList.highScores[i+3].playerName;
                            }
                            thisList.highScores[i + 3].playerTime =
                                thisList.highScores[i+2].playerTime;
                            thisList.highScores[i + 3].playerName =
                                thisList.highScores[i+2].playerName;
                        }
                        thisList.highScores[i + 2].playerTime =
                            thisList.highScores[i+1].playerTime;
                        thisList.highScores[i + 2].playerName =
                            thisList.highScores[i+1].playerName;
                    }
                    thisList.highScores[i + 1].playerTime =
                        thisList.highScores[i].playerTime;
                    thisList.highScores[i + 1].playerName =
                        thisList.highScores[i].playerName;
                }

                thisList.highScores[i].playerTime = time;
                thisList.highScores[i].playerName = name;
               
                return true;
            }
        }

        return false;
    }

    private void SetInitialScores()
    {
        thisList = new HighScoreData();
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

