using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HeroGeneretor : MonoBehaviour
{
    [SerializeField]
    float _interval = 5f;
    float _timer = 0f;

    List<Cell> _heroSpawnList = new List<Cell>();
    
    public void AddSpawnCell(Cell cell)
    {
        _heroSpawnList.Add(cell);
    }
    List<GameObject> _heroList = new List<GameObject>();
    public void RemoveHero(GameObject go)
    {
        _heroList.Remove(go);
    }
    MinionParamator[] _minionPrefabs;
    public void OnStart()
    {
        var cellmane = GameManager.Instance.CellManagerInstans;
        _minionPrefabs = Resources.LoadAll<MinionParamator>("HeroPrefabs");
        for (int c = 0;c< cellmane.Colm;c++)
        {
            for (int r = 0; r < cellmane.Row; r++)
            {
                var cell = cellmane.CellArray[c, r];
                if (cell.CurrentCellType ==CellTypes.HeroArea)
                {
                    _heroSpawnList.Add(cell);
                }
            }
        }
    }
    public void OnUpdate()
    {
        _timer += Time.deltaTime;
        if (_timer>_interval)
        {
            GenerateHero();
            _timer = 0f;            
        }

        _heroList.ForEach(x => x.GetComponent<MinionAttack>().OnUpdate());
    }

    void GenerateHero()
    {
        if (_heroSpawnList.Count<=0)
        {
            return;
        }
        int sRand = Random.Range(0, _heroSpawnList.Count);
        int hRand = Random.Range(0,_minionPrefabs.Length);
        var minion = Instantiate(_minionPrefabs[hRand], _heroSpawnList[sRand].transform);
        _heroSpawnList[sRand].MinionOnCell = minion;
        _heroSpawnList[sRand].CurrentCellType = CellTypes.AlreadyHero;
        _heroSpawnList.Remove(_heroSpawnList[sRand]);
        _heroList.Add(minion.gameObject);
    }
}
