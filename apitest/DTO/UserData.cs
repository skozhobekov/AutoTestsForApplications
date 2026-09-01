namespace apitest.DTO;

public class UserData
{
    public string Name { get; set; }
    public string Id { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public string Role { get; set; }
    public List<string> Tags { get; set; }
    public Address Address { get; set; }
}

public class Address
{
    public string Street { get; set; }
    public Coordinates Coordinates { get; set; }
}

public class Coordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}