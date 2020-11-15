using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfos : MonoBehaviour
{
    
    public int[] level1SoulRequired = new int[]{0,3,3,3,5,0};
    public int[] level2SoulRequired = new int[]{0,3,5,4,0,6,0};

    public bool shouldIGoNext(int level, int part, int progression)
    {
        if (level == 1)
        {
            if (progression >= level1SoulRequired[part])
            {
                return true;
            }
        }
        if (level == 2)
        {
            if (progression >= level2SoulRequired[part])
            {
                return true;
            }
        }
        return false;
    }

    public bool didIWin(int level, int part)
    {
        if (level == 1)
        {
            if (part >= level1SoulRequired.Length)
            {
                return true;
            }
        }
        if (level == 2)
        {
            if (part >= level2SoulRequired.Length)
            {
                return true;
            }
        }
        return false;
    }

    public int getSoulRequired(int level,int part)
    {
        if (level == 1)
        {
            return level1SoulRequired[part];
        }
        if (level == 2)
        {
            return level2SoulRequired[part];
        }
        return 0;
    }
}
