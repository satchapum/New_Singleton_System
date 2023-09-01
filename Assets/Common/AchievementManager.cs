using PhEngine.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperGame
{
    public class AchievementManager : Singleton<AchievementManager>
    {

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
                        Debug.Log("Pop-up achievement");
                        //pop-up_achievement_here
                    }
                }
            }
        }
    }

    [Serializable]
    public class Achievement
    {
        public string achievementGoal;
        public int numberOfCondition;
        public int currentNumberCondition;
        public bool isComplete;
    }
}

