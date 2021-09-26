using System.Collections.Generic;
using UnityEngine;


public class TeamFactory
{
    private BaseTeam _redTeam;
    private BaseTeam _blueTeam;
    private Vector3 _redStartPosition = new Vector3(-4, -4, 0);
    private Vector3 _blueStartPosition = new Vector3(4, -4, 0);
    private float _delta = 1.5f;

    public BaseTeam RedTeam  => _redTeam;

    public BaseTeam BlueTeam => _blueTeam;

    public TeamFactory()
    {
        CreateRedTeam();
        CreateBlueTeam();
    }

    private void CreateRedTeam()
    {
        _redTeam = new BaseTeam();
        float temp = 0;
        bool indented = false;

        for (int i = 0; i < 7; i++)
        {
            _redTeam.Warriors.Add(ObjectPool.Instance.GetObject(ObjectType.Warrior).GetComponent<BaseWarrior>());
        }

        _redTeam.Warriors[0].SetSpecifications(ArmyType.Red, 8, 4);
        _redTeam.Warriors[1].SetSpecifications(ArmyType.Red, 8, 4);
        _redTeam.Warriors[2].SetSpecifications(ArmyType.Red, 9, 5);
        _redTeam.Warriors[3].SetSpecifications(ArmyType.Red, 4, 3);
        _redTeam.Warriors[4].SetSpecifications(ArmyType.Red, 2, 3);
        _redTeam.Warriors[5].SetSpecifications(ArmyType.Red, 3, 4);
        _redTeam.Warriors[6].SetSpecifications(ArmyType.Red, 1, 1);

        SpriteRenderer[] spriteRenderers;
        foreach (BaseWarrior baseWarrior in _redTeam.Warriors)
        {
             spriteRenderers = baseWarrior.GetComponentsInChildren<SpriteRenderer>();

            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.color = Color.red;
            }

            if (indented)
            {
                baseWarrior.transform.position = _redStartPosition + new Vector3(_delta, temp, 0);
                temp += _delta;
                indented = false;
            }
            else
            {
                baseWarrior.transform.position = _redStartPosition + new Vector3(0, temp, 0);
                temp += _delta;
                indented = true;
            }

            baseWarrior.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            baseWarrior.gameObject.SetActive(true);
        }
    }

    private void CreateBlueTeam()
    {
        _blueTeam = new BaseTeam();
        float temp = 0;
        bool indented = false;

        for (int i = 0; i < 7; i++)
        {
            _blueTeam.Warriors.Add(ObjectPool.Instance.GetObject(ObjectType.Warrior).GetComponent<BaseWarrior>());
        }

        _blueTeam.Warriors[0].SetSpecifications(ArmyType.Blue, 6, 6);
        _blueTeam.Warriors[1].SetSpecifications(ArmyType.Blue, 8, 5);
        _blueTeam.Warriors[2].SetSpecifications(ArmyType.Blue, 9, 5);
        _blueTeam.Warriors[3].SetSpecifications(ArmyType.Blue, 8, 4);
        _blueTeam.Warriors[4].SetSpecifications(ArmyType.Blue, 2, 3);
        _blueTeam.Warriors[5].SetSpecifications(ArmyType.Blue, 4, 2);
        _blueTeam.Warriors[6].SetSpecifications(ArmyType.Blue, 1, 1);

        SpriteRenderer[] spriteRenderers;
        foreach (BaseWarrior baseWarrior in _blueTeam.Warriors)
        {
            spriteRenderers = baseWarrior.GetComponentsInChildren<SpriteRenderer>();

            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.color = Color.blue;
            }

            if (indented)
            {
                baseWarrior.transform.position = _blueStartPosition + new Vector3(_delta, temp, 0);
                temp += _delta;
                indented = false;
            }
            else
            {
                baseWarrior.transform.position = _blueStartPosition + new Vector3(0, temp, 0);
                temp += _delta;
                indented = true;
            }

            baseWarrior.gameObject.SetActive(true);
        }
    }
}