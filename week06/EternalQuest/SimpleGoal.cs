public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override string GetDetailsString()
    {
        return $"{_name} - {_description} ({_points} points)";
    }

    public override string GetStatus()
    {
        return _isComplete ? "[X]" : "[ ]";
    }
}
