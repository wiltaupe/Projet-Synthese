﻿using System;
using System.Collections.Generic;
using UnityEngine;
public class PlaneteManager : MonoBehaviour
{

    GameObject planeteReg;
    public static PlaneteManager Instance { get; private set; }
    public List<GameObject> planetesPrefab;
    private Dictionary<int, (GameObject,int)> p;
    private Dictionary<int, (Vector3 vecteurPosition,float rotationZ,int selection)> actif = new();
    private int position;
    private bool fait;
    private bool debut = false;
    private Vector3 posSelection;
    private int indexPos;
    public Planete currentEvent;
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        this.transform.SetParent(GameObject.Find("MainManager").transform);
        var parentLigne = new GameObject();
        parentLigne.name = "ObjetLigne";
    }

    public int VerificationPosition(float x)
    {
        int position = 11;

        for (double i = (x + 55); i < 455; i += 45.5)
        {
            position -= 1;
        }

        return position;
    }

    private double DistancePlanete(Vector3 p1, Vector3 p2)
    {
        return Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2));
    }


    public bool VerificationRayon(Vector3 vecteur, float rayon)
    {
        foreach (var planete in actif.Values)
        {
            if (DistancePlanete(vecteur, planete.vecteurPosition) < rayon)
            {
                return true;
            }
        }
        return false;
    }

    public int min(int posi, List<(GameObject, int)> list)
    {
        int max = posi;
        int pos = 0;
        int min = 0;

        foreach (var planete in list)
        {
            int pospla = planete.Item2;

            if (min < pospla && pospla < max)
            {
                pos = pospla;
            }
        }

        return posi - pos;
    }

    public void VerificationPath(GameObject g = null)
    {

        if (!fait)
        {
            for (int i = 0; i < p.Count; i++)
            {
                Vector3 TEST = p[i].Item1.transform.position;

                for (int j = 0; j < p.Count; j++)
                {
                    Planete positionVerif = p[j].Item1.GetComponent<Planete>();

                    double distance = DistancePlanete(p[j].Item1.transform.position, TEST);

                    if (VerificationPosition(TEST.x) == VerificationPosition(p[j].Item1.transform.position.x) - 1)
                    {

                        if (distance < 110f)
                        {
                            CreationLigne(p[i].Item1, p[j].Item1);
                            positionVerif.possedeCheminDerriere = true;
                        }
                    }
                }
            }
        }

        else
        {
            Planete cheminAV = g.GetComponent<Planete>();
            double distancepetit = double.PositiveInfinity;
            int positionAVANT = 0;

            for (int k = 0; k < p.Count; k++)
            {
                double distance = DistancePlanete(p[k].Item1.transform.position, posSelection);

                if (VerificationPosition(posSelection.x) == VerificationPosition(p[k].Item1.transform.position.x) - 1)
                {

                    if (distance < 110f) // -55 en x
                    {
                        CreationLigne(g, p[k].Item1);
                        cheminAV.possedeCheminDevant = true;
                        p[k].Item1.GetComponent<Planete>().possedeCheminDerriere = true;
                    }

                    if (distance < distancepetit)
                    {
                        distancepetit = distance;
                        positionAVANT = k;
                    }
                }
            }

            if (!cheminAV.possedeCheminDevant && VerificationPosition(posSelection.x) != 10)
            {
                CreationLigne(g, p[positionAVANT].Item1);
            }      
        }
    }

    public void CreationLigne(GameObject ini, GameObject fin)
    {
        var go = new GameObject();
        go.transform.SetParent(GameObject.Find("ObjetLigne").transform);
        var lr = go.AddComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));

        lr.SetPosition(0, ini.transform.position);
        lr.SetPosition(1, fin.transform.position);
        lr.startColor = Color.cyan;
        lr.endColor = Color.cyan;
    }

    public (float, float, float) GenererUnePlanete()
    {
        float x = UnityEngine.Random.Range(-55, 400);
        float y = UnityEngine.Random.Range(-205, 95);
        float rotation = UnityEngine.Random.Range(0, 360);

        return (x, y, rotation);
    }

    public void GenererPlanetes(int valeur)
    {
        for (int i = 0; i < valeur; i++)
        {
            int randomPlanetePrefeb = UnityEngine.Random.Range(0, planetesPrefab.Count);
            float rotation = UnityEngine.Random.Range(0, 360);

            if (i == 0)
            {
                actif[0] = (new Vector3(-55, 95),rotation, randomPlanetePrefeb);
            }

            else
            {
                var objet = GenererUnePlanete();

                if (!VerificationRayon(new Vector3(objet.Item1,objet.Item2,0), 40f))
                {
                    actif[actif.Count] = (new Vector3(objet.Item1, objet.Item2), objet.Item3, randomPlanetePrefeb);
                }
            }
        }
    }

    public void GenererPathPlanete()
    {
        bool f = false;

        for (int k = 0; k < p.Count; k++)
        {
            if (p[k].Item1.transform.position == posSelection)
            {
                indexPos = k;
            }

            f = true;
        }

        if (f)
        {
            VerificationPath(p[indexPos].Item1);
        }

        else
        {
            VerificationPath();
        }
    }


    public void PlacerActif()
    {
        p = new();

        for (int i = 0; i < actif.Count; i++)
        {
            GameObject selection = planetesPrefab[actif[i].selection];
            GameObject c = Instantiate(selection, actif[i].vecteurPosition,Quaternion.identity);
            c.transform.SetParent(GameObject.Find("ObjetPlanete").transform);
            c.transform.Rotate(0, 0, actif[i].rotationZ, Space.Self);
            p[i] = (c, i);
        }

        GenererPathPlanete();
    }

    public int GetPosition() {return position;}
    public bool GetDebut() {return debut;}
    public bool GetFait() {return fait;}
    public void SetPosition(int p) {position = p;}
    public void SetDebut(bool d) {debut = d;}
    public void SetFait(bool f) {fait = f;}
    public void SetposSelection(Vector3 f) {posSelection = f;}

}