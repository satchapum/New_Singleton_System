using PhEngine.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace SuperGame
{
    public class AchievementManager : Singleton<AchievementManager>
    {
        [Header("AchievementUI")]
        [SerializeField] TMP_Text achievementNameTextUI;
        [SerializeField] TMP_Text achievementDescriptionTextUI;
        [SerializeField] GameObject achievementUI;

        [SerializeField] List<Achievement> achievementsList = new List<Achievement>();
        public List<Achievement> AchievementsList => achievementsList;
        

        
        protected override void InitAfterAwake()
        {
            
        }

        public void AchievementComplete(string achievementGoal)
        {
            bool isItTime = false;
            CheckAchievementComplete(achievementGoal, 0, isItTime);

        }

        public void AchievementCompleteAboutTime(string achievementGoal, int time)
        {
            bool isItTime = true;
            CheckAchievementComplete(achievementGoal, time, isItTime);
        }

        void CheckAchievementComplete(string achievementGoal, int time, bool isItTime)
        {
            foreach (Achievement achievement in AchievementsList)
            {
                if (achievement.achievementGoal == achievementGoal && achievement.isComplete == false)
                {
                    if(isItTime == false)
                        achievement.currentNumberCondition++;
                    else
                        achievement.currentNumberCondition = time;

                    if (achievement.currentNumberCondition == achievement.numberOfCondition)
                    {
                        achievement.isComplete = true;
                        StartCoroutine(AchievementPopupShowtime(achievement.achievementName , achievement.achievementGoal));
                        Debug.Log("Pop-up achievement");
                        //pop-up_achievement_here
                    }
                }
            }
        }
       
        IEnumerator AchievementPopupShowtime(string achievementName, string achievementGoal)
        {
            achievementUI.SetActive(true);
            achievementNameTextUI.text = achievementName;
            achievementDescriptionTextUI.text = achievementGoal;
            yield return new WaitForSeconds(2);
            achievementUI.SetActive(false);
        }
    }

    [Serializable]
    public class Achievement
    {
        public string achievementName;
        public string achievementGoal;
        public int numberOfCondition;
        public int currentNumberCondition;
        public bool isComplete;
    }


}

