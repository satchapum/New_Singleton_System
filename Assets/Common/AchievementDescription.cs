using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementDescription : MonoBehaviour
{
    [SerializeField] TMP_Text achievementName;
    [SerializeField] TMP_Text achievementDescription;
    [SerializeField] TMP_Text achievementIsComplete;
    [SerializeField] TMP_Text currentAchieveStatus;
    
    public void SetData(string name, string desciption, bool isComplete, string currentStatus)
    {
        achievementName.text = name;
        achievementDescription.text = desciption;

        if (isComplete == true)
        {
            currentAchieveStatus.text = "";
            achievementIsComplete.text = "Complete";
        }
        else
        {
            currentAchieveStatus.text = currentStatus;
            achievementIsComplete.text = "InComplete";
        }
    }
}
