namespace LabBooker.Domain.ValueObjects;

public record TimeRange
{
    public DateTime StartDate { get; init; }
    public TimeSpan Duration { get; init; }
    public DateTime EndDate => StartDate.Add(Duration);
    public TimeRange(DateTime start, TimeSpan duration)
    {
        if (start > DateTime.Now)
        {
            StartDate = start;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Die Startzeit ist in der Vergangenheit!");
        }

        if (duration > TimeSpan.Zero)
        {
            Duration = duration;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Die Duration darf nicht 0 sein!");
        }
    }

    public bool Overlaps(TimeRange other)
    {
        DateTime start = other.StartDate;
        DateTime end = other.EndDate;
        if (EndDate <= start || end <= StartDate)
        {
            return false;
        }
        return true;
    }
}