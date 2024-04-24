using System;
using System.Collections.Generic;
using UnityEngine;

public class Survival
{
    bool survivingCondition() { return false; }
    static bool checkSurvival(Organism org)
    {
        if (org.loc.y <= Globals.WORLD_SIZE / 2)
        {
            return true;
            /*if (org.loc.x <= Globals.WORLD_SIZE / 2)
            {
                return true;
            }*/
        }
        return false;
    }


    public static void GotoNextGen()
    {
        int count = 0;
        for (int i = 0; i < Globals.numberOfOrganisms; i++)
        {
            if (!checkSurvival(Globals.organisms[count]))
            {
                GameObject.Destroy(Globals.organisms[count].prefab);
                Globals.organisms.RemoveAt(count);
                count--;
            }
            count++;
        }

        Globals.setWorldtoZero();

        List<Organism> children = new List<Organism>();

        int p = Globals.organisms.Count;
        for (int i = 0; i < Globals.numberOfOrganisms; i++)
        {
            children.Add(Globals.organisms[i % p].getChild());
        }
        for (int i = 0;i < p;i++)
        {
            GameObject.Destroy(Globals.organisms[i].prefab);
        }
        Globals.organisms.Clear();
        for (int i = 0;i < Globals.numberOfOrganisms;i++)
        {
            Globals.organisms.Add(children[i]);
        }
        children.Clear();
    }
}
