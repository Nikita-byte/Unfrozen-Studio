using System;
using System.Collections.Generic;


public class BaseTeam
{
    private List<BaseWarrior> _warriors = new List<BaseWarrior>();

    public List<BaseWarrior> Warriors => _warriors;

    public void Clean()
    {
        foreach (BaseWarrior baseWarrior in _warriors)
        {
            ObjectPool.Instance.ReturnInPool(ObjectType.Warrior, baseWarrior.gameObject);
        }

        _warriors.Clear();
    }
}
