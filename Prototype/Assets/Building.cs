/// <summary>
/// Building Class
/// </summary>
public class Building {
    public string name          { get; set; }   // Name of the building
    public string description   { get; set; }   // A short description that pop when you pass your mouse on his UI icon
    public int electricity      { get; set; }   // How many electricity gives the building
    public int water            { get; set; }   // How many water gives the building
    public int green_score      { get; set; }   // how many green_score gives the building
    public int pollution        { get; set; }   // how many pollution score gives the building
    public int population       { get; set; }   // how many population gives the building
    public int price            { get; set; }   // How much money you need to build the building
}
