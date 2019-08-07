using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MapManager
{
    private static MapManager _instance;
    public static MapManager GetInstance
    {
        get
        {
            if (_instance==null)
            {
                _instance = new MapManager();
            }
            return _instance;
        }
    }

    Map _map;

    public void SetMap(Map map)
    {
        _map = map;
    }

    public Map GameMap
    {
        get
        {
            return _map;
        }
    }
}
