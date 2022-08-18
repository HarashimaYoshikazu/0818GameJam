using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager:Singleton<GameManager>
{
    CellManager _cellManager = null;
    public CellManager CellManagerInstans
    {
        get
        {
            if (!_cellManager)
            {
                _cellManager = GameObject.FindObjectOfType<CellManager>();
                if (!_cellManager)
                {
                    CellManager go = Resources.Load<CellManager>("UIPrefabs/CellCanvas");
                    _cellManager= GameObject.Instantiate(go);
                }
            }
            return _cellManager;
        }
    }
}
