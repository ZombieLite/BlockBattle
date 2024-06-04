using UnityEngine;
using UnityEngine.Events;

public class LevelPlayer : MonoBehaviour 
{
    [SerializeField] GameObject effect;
    public static LevelPlayer instance { get; private set; }

    public static UnityEvent LevelUpdate = new UnityEvent();

    private void Awake()
    {
        if (instance == null)
            instance = this;

        LevelTable();
    }

    private void Start()
    {
        LevelUpdate?.Invoke();
    }

    private int[] _levelTable = new int[500 + 5];
    private int _level = 1;
    private int _exp = 0;

    public int GetLevel()
    {
        return _level;
    }

    public void SetLevel(int level)
    {
        if (level < _level)
            return;

        Ability.SetAbility(Ability.GetAbility() + (level - _level));

        if (level > 500)
            return;

        _level = level;  
    }

    public int GetExp()
    {
        return _exp;
    }

    public void SetExp(int exp)
    {
        _exp = exp;
        LevelUpdate?.Invoke();
    }

    public int GetMaxExp()
    {
        return _levelTable[_level + 1];
    }

    public void AddExp(int exp)
    {
        _exp += exp;

        if(_exp >= _levelTable[_level + 1])
        {
            _exp -= _levelTable[_level + 1];
            instance.GetComponent<AudioSource>().Play();
            GameObject _effect = Instantiate(effect);
            Destroy(_effect, 2.0f);
            SetLevel(_level + 1);
            Core.SaveProgress();
        }
        LevelUpdate?.Invoke();
    }

    private void LevelTable()
    {
        float _bufferExp = 10;
        _levelTable[1] = 0;
        _levelTable[0] = 0;
        for (int i = 2; i < _levelTable.Length; i++)
        {
            _levelTable[i] = Mathf.RoundToInt(_bufferExp);

            if (i <= 50)
                _bufferExp += 15;
            else if (i <= 100)
                _bufferExp *= 1.05f;
            else if (i <= 150)
                _bufferExp *= 1.02f;
            else if (i <= 200)
                _bufferExp *= 1.009f;
            else
                _bufferExp *= 1.005f;

            if (_bufferExp > 100000)
                _bufferExp = 100000;
        }
    }
}