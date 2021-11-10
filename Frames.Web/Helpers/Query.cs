namespace Frames.Web.Helpers;

public class Query
{
    public string Filter { get; set; }
    public object[] FilterParameters { get; set; }
    public string OrderBy { get; set; }
    public string Expand { get; set; }
    public int? Skip { get; set; }
    public int? Top { get; set; }
}
