namespace myportfolio.Pages;

public class PortfolioData
{
    public string Name { get; set; } = "";
    public string Badge { get; set; } = "";
    public string Intro { get; set; } = "";
    // currently not used
    public string Tagline { get; set; } = "";
    public string Desc { get; set; } = "";
    public List<StatItem> Stats { get; set; } = new();
    public List<string> Services { get; set; } = new();
    public List<ExperienceItem> Experience { get; set; } = new();
    public List<SkillGroup> Skills { get; set; } = new();
    public List<ProjectItem> Projects { get; set; } = new();
    public List<AchievementItem> Achievements { get; set; } = new();
    public List<string> AchievementImages { get; set; } = new();
    public ContactInfo Contact { get; set; } = new();
}

public class StatItem
{
    public string Value { get; set; } = "";
    public string Label { get; set; } = "";
}

public class ExperienceItem
{
    public string Title { get; set; } = "";
    public string Company { get; set; } = "";
    public string Location { get; set; } = "";
    public string Duration { get; set; } = "";
    public string Summary { get; set; } = "";
}

public class SkillGroup
{
    public string Icon { get; set; } = "";
    public string Title { get; set; } = "";
    public List<string> Tags { get; set; } = new();
    public bool HighlightFirst { get; set; }
}

public class ProjectItem
{
    public string Category { get; set; } = "";
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public List<string> TechStack { get; set; } = new();
    public List<ProjectImage> Images { get; set; } = new();
}

public class ProjectImage
{
    public string Src { get; set; } = "";
    public string Alt { get; set; } = "";
}

public class AchievementItem
{
    public string Label { get; set; } = "";
    public string Text { get; set; } = "";
}

public class ContactInfo
{
    public string Message { get; set; } = "";
    public string Phone { get; set; } = "";
    public string PhoneHref { get; set; } = "";
    public string Email { get; set; } = "";
    public string Linkedin { get; set; } = "";
}