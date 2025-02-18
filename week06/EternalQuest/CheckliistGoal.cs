public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            if (_currentCount == _targetCount)
            {
                return _points + _bonusPoints;
            }
            return _points;
        }
        return 0;
    }

    public override string GetDetailsString()
    {
        return $"{_name} - {_description} ({_points} points per completion, Bonus: {_bonusPoints} at {_targetCount} times)";
    }

    public override string GetStatus()
    {
        return $"Completed {_currentCount}/{_targetCount} times";
    }
}
