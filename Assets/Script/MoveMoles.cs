using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveMoles : MonoBehaviour
{
    //Moleのオブジェクト
    public List<GameObject>Moles=new List<GameObject>();
    //Moleが動いているかどうか判定
    public List<bool>IsMoving=new List<bool>(){true,false,false};
    //Moleが完全に隠れるY座標
    public float HideMoleYPos = 6.5f;
    //Moleが出てくる最大Y座標
    public float AppearMoleYPos = 7.5f;
    //Moleが動くスピード
    public float MoveSpeed = 3.0f;
    public float HideSpeed = 3.0f;
    
    public List<int> randomMoleNum = new List<int>(){0,1,2};
    private List<int> nums = new List<int>();
    //上昇中のフラグ
    public List<bool> Rising = new List<bool>() { false,false,false};
    
    
    void Start()
    {
        SetUp();
    }
    
    void Update()
    {
        MoveMole();   
    }

    void SetUp()
    {
        GetRandomNum();
        foreach (GameObject Moles in Moles)
        {
            Vector3 molePos = Moles.transform.localPosition;
            molePos.y=HideMoleYPos; 
            Moles.transform.localPosition = molePos;
        }
    }
    

    void MoveMole()
    {
        for (int i = 0; i < IsMoving.Count; i++)
        {
            if (IsMoving[i])
            {
                if (IsMoving[i])
                {
                    if (AppearMoleYPos >= Moles[randomMoleNum[i]].transform.position.y&&!MoleClick.IsClicked)
                    {
                        Rising[i] = true;
                    }
                    else if (AppearMoleYPos <= Moles[randomMoleNum[i]].transform.position.y||MoleClick.IsClicked)
                    {
                        Debug.Log(MoleClick.IsClicked+"ByMoveMole");
                        Rising[i] = false;
                    }
                }
            }

            if (Rising[i])
            {
                UpMole();
            }
            else
            {
                if (HideMoleYPos <= Moles[randomMoleNum[i]].transform.position.y)
                {
                    DownMole();
                    IsMoving[i] = false;
                    if (HideMoleYPos >= Moles[randomMoleNum[i]].transform.position.y)
                    {
                        IsMoving[i] = true;
                        MoleClick.IsClicked = false;
                        GetRandomNum();
                    }
                }
            }
        }
    }
    
    void GetRandomNum()
    {
        for (int i = 0; i < IsMoving.Count; i++)
            randomMoleNum[i] = Random.Range(0, Moles.Count);
    }

    void UpMole()
    {
        for (int i = 0; i < IsMoving.Count; i++)
            Moles[randomMoleNum[i]].transform.position+=new Vector3(0, MoveSpeed, 0)*Time.deltaTime;
    }
    void DownMole()
    {
        for (int i = 0; i < IsMoving.Count; i++)
            Moles[randomMoleNum[i]].transform.position-=new Vector3(0, MoveSpeed+HideSpeed, 0)*Time.deltaTime;
    }
}
