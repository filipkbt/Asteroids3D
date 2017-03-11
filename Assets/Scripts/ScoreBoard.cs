//skrypt ScoreBoard - podpiety do Spawner .



using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Linq;

public class Score
{

    public string name { get; set; }

    public int number { get; set; }

    public Score()
    {

    }
    public Score(string name, int number)
    {
        this.name = name;
        this.number = number;
    }
    public override string ToString()
    {
        return name + ": " + number;
    }
}

public class ScoreBoard : MonoBehaviour
{
    public List<Score> scoreList;
    public Text MyText;
    private XmlSerializer ser;
    void Start()
    {
        scoreList = new List<Score>();
        scoreList.Sort((x, y) => x.number.CompareTo(y.number));
        ser = new XmlSerializer(typeof(List<Score>));
        loadScores();
        int tmpListCount = scoreList.Count;
        if(tmpListCount > 10)
        {
            tmpListCount = 10;
        }

        for (int y = 0; y < tmpListCount ; y++)
        {
            MyText.text =   MyText.text + scoreList[y].ToString() + System.Environment.NewLine;
            
            
        }
    }
    void Update() { }

    public void AddScore(string name, int scoreValue)
    {
        Score tmp = new Score(name, scoreValue);
        scoreList.Add(tmp);
        sortScores();
        saveScores();
    }

    public void saveScores()
    {
        using (var fs = new FileStream("ScoreBoardFile.xml", FileMode.Create))
        {
            ser.Serialize(fs, scoreList);
            fs.Close();
        }
    }
    public void loadScores()
    {
        using (var fs = new FileStream("ScoreBoardFile.xml", FileMode.Open))
        {
            XmlReader reader = XmlReader.Create(fs);
            scoreList = (List<Score>)ser.Deserialize(reader);

            fs.Close();
        }
        sortScores();
    }

    public void sortScores()
    {
        scoreList = scoreList.OrderByDescending(o => o.number).ToList();
    }

}
