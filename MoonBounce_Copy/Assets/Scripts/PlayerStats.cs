using System.Collections;
using System;

public static class PlayerStats
{
    private static bool[] completedLevels = {false, false, false, false};
    private const int levelCount = 4;
    private static bool active = false;

    public static void SetLevelCompleted(int levelNum)
    {
        if (levelNum < levelCount)
        {
            completedLevels[levelNum] = true;
        }

    }

    public static bool CheckIsCompleted(int levelNum)
    {
        if (levelNum < levelCount)
        {
            return completedLevels[levelNum];
        }
        return false;
    }

    public static bool AllLevelsCompleted()
    {
        return (GetNextLevel() == -1);
    }

    public static int GetNextLevel()
    {
      for (int x = 0; x < levelCount; x++)
      {
          if (completedLevels[x] == false)
          {
              return x;
          }
      }
      return -1;
    }

    public static int GetLevelCount()
    {
        return levelCount;
    }

    public static void Clear()
    {
        for (int x = 0; x < levelCount; x++)
        {
            completedLevels[x] = false;
        }
    }

    public static void SetActive(bool a)
    {
        active = a;
        Clear();
    }

    public static bool GetActive()
    {
        return active;
    }


}
