namespace Karen.Common.Dto;
public class NavigatorCategory {
    public required int Id { get; set; }
    public required int ParentId { get; set; }
    public required string Name { get; set; }
    public required bool IsNode { get; set; }
    public required bool IsPublicSpace { get; set; }
    public required bool IsTradingAllowed { get; set; }
    public required int MinAccess { get; set; }
    public required int MinAssign { get; set; }
    public IEnumerable<NavigatorCategory> Subcategories { get; set; } = [];
    public ICollection<NavigatorNode> Nodes { get; set; } = [];
}
