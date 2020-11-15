using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfos : MonoBehaviour
{
    

    public int[] tutorielSoulRequired = new int[]{10};
    public int[] level1SoulRequired = new int[]{0,3,3,3,5,0};
    public int[] level2SoulRequired = new int[]{0,3,5,4,0,6,0};


    [SerializeField]
    public MonsterManager.Pattern[] patterns1P1;

    [SerializeField]
    public MonsterManager.Pattern[] patterns1P2;

    [SerializeField]
    public MonsterManager.Pattern[] patterns1P3;

    [SerializeField]
    public MonsterManager.Pattern[] patterns1P4;

    [SerializeField]
    public MonsterManager.Pattern[] patterns2P1;

    [SerializeField]
    public MonsterManager.Pattern[] patterns2P2;

    [SerializeField]
    public MonsterManager.Pattern[] patterns2P3;

    [SerializeField]
    public MonsterManager.Pattern[] patterns2P4;

    [SerializeField]
    public MonsterManager.Pattern[] patterns0A;
    [SerializeField]
    public MonsterManager.Pattern[] patterns0B;
    [SerializeField]
    public MonsterManager.Pattern[] patterns0C;
    [SerializeField]
    public MonsterManager.Pattern[] patterns0D;
    [SerializeField]
    public MonsterManager.Pattern[] patterns0E;


    public MonsterManager.Pattern[] getCurrentPatterns(int level, int part)
    {
        switch(level)
        {
            case 0:
                switch(part)
                {
                    case 2:
                        return patterns0A;
                    case 3:
                        return patterns0A;
                    case 4:
                        return patterns0B;
                    case 5:
                        return patterns0B;
                    case 6:
                        return patterns0C;
                    case 7:
                        return patterns0C;
                    case 8:
                        return patterns0D;
                    case 9:
                        return patterns0D;
                    case 10:
                        return patterns0E;
                    default:
                        return patterns0E;
                }
            case 1:
                switch(part)
                {
                    case 1:
                        return patterns1P1;
                    case 2:
                        return patterns1P2;
                    case 3:
                        return patterns1P3;
                    case 4:
                        return patterns1P4;
                    default:
                        return patterns1P1;
                }
            case 2:
                switch(part)
                {
                    case 1:
                        return patterns2P1;
                    case 2:
                        return patterns2P2;
                    case 3:
                        return patterns2P3;
                    case 5:
                        return patterns2P4;
                    default:
                        return patterns1P1;
                }
            default:
                return patterns1P1;
        }
    }

    public bool shouldIGoNext(int level, int part, int progression)
    {
        if (level == 0)
        {
            if (progression >=10)
            {
                return true;
            }
        }
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
        if (level == 0)
        {
            if (part >= 1)
            {
                return true;
            }
        }

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
        if (level == 0)
        {
            return tutorielSoulRequired[0];
        }
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
