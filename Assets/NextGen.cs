using System;
using UnityEngine;

public class Survival
{
    bool survivingCondition() { return false; }
    static bool checkSurvival(Organism org)
    {
        if (org.loc.y <= Globals.WORLD_SIZE / 2)
        {
            return true;
        }
        return false;
    }


    public static void PlaceholderName()
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

        for (int i = 0; i < Globals.organisms.Count; i++)
        {
            Globals.organisms[i].loc = new Cords();
        }

        int k = Globals.numberOfOrganisms;
        int p = Globals.organisms.Count;
        for (int i = 0; i < k - p; i++)
        {
            Globals.organisms.Add(Globals.organisms[i % p].getChild());
        }
    }
}
