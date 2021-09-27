using System;
using UnityEngine;

public class BaseWarrior : MonoBehaviour, IComparable
{
    [SerializeField] private ArmyType _armyType;
    [SerializeField] private int _initiative;
    [SerializeField] private int _speed;
    [SerializeField] private bool _isDead;
    [SerializeField] private bool _isInactive;

    private int _currentRound = 1;
    private Animator _animator;

    public ArmyType ArmyType { get => _armyType; }
    public int Initiative { get => _initiative; }
    public int Speed { get => _speed; }
    public bool IsDead;
    public bool IsInactive;

    private void Awake()
    {
        EventManager.Instance.Round += SetRound;
        _animator = GetComponent<Animator>(); 
    }

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        BaseWarrior warrior = obj as BaseWarrior;

        if (warrior != null)
        {
            if (_initiative == warrior.Initiative)
            {
                if (_speed == warrior.Speed)
                {
                    switch (_armyType)
                    {
                        case ArmyType.Red:
                            if ((_currentRound % 2) == 0)
                            {
                                return -1;
                            }
                            else return 1;
                        case ArmyType.Blue:
                            if ((_currentRound % 2) == 0)
                            {
                                return 1;
                            }
                            else return -1;
                    }
                    return 0;
                }
                else return _speed.CompareTo(warrior.Speed);
            }
            else
            {
                return _initiative.CompareTo(warrior.Initiative);
            }
        }
        else
        {
            throw new ArgumentException("Object is not a warrior");
        }    
    }

    public virtual void SetSpecifications(ArmyType armyType, int initiative, int speed)
    {
         _armyType = armyType;
         _initiative = initiative;
         _speed = speed;
    }

    public virtual void Die()
    {
        IsDead = true;
        IsInactive = true;
        _animator.SetBool("Die", true);
    }

    public virtual void Life()
    {
        IsDead = false;
        _animator.SetBool("Die", false);
    }

    private void SetRound(int round)
    {
        _currentRound = round;
    }
}
