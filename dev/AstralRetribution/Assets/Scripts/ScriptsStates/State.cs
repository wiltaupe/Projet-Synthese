using System;
using System.Collections;

public abstract class State
{
    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual void TempsFini()
    {

    }

    public virtual void Attack()
    {

    }

    public virtual void PlayCard(Carte carte)
    {

    }

    public virtual void PlayCard(Carte carte,Salle cible)
    {

    }
}