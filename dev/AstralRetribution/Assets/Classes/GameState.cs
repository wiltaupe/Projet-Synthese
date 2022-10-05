using UnityEngine;

internal class GameState : State
{

    public override void Start()
    {
        GenererVaisseau();
        GenererCarte();
    }


    public override void GenererVaisseau()
    {
        base.GenererVaisseau();
    }

    public override void GenererCarte()
    {
        base.GenererCarte();
    }

    public override void AppuyerPlanète(Planete planete)
    {
        base.AppuyerPlanète(planete);
    }


}