// Test task at sobes with guys from "Informatiom systems in Health Care"
// (ООО Информационные Системы в Здравоохранении).

// Select cities from the next collection which are located at the same Latitude,
// count and sort them using Linq extention.

List<City> cities = new List<City> {
	new City("Tokyo", new Location(11.120, 3)),
	new City("Delhi",new Location(12.120, 14.450)),
	new City("Shanghai", new Location(11.120, 14.550)),
	new City("São Paulo", new Location(14.120, 16.650)),
	new City("Mumbai", new Location(15.120, 17.750)),
	new City("Beijing", new Location(16.120, 14.850)),
	new City("Cairo",new Location(17.120, 14.0)),
	new City("Dhaka", new Location(18.120, 14.234)),
	new City("Osaka", new Location(17.120, 14.56)),
	new City("New York-Newark",new Location(18.120, 66.850)),
	new City("Karachi", new Location(120.120, 77.850)),
	new City("Chongqing", new Location(121.120, 88.850)),
	new City("Istanbul", new Location(122.120, 99.850)),

	new City("Kolkata", new Location(18.120, 14.850)),
	new City("Lagos", new Location(17.120, 14.368)),
	new City("Kinshasa", new Location(18.120, 14.342)),
	new City("Manila", new Location(18.720, 13.923)),
	new City("Rio de Janeiro", new Location(18.120, 13.374)),
	new City("Tianjin", new Location(13.215, 18.160))
};

var list = cities.GroupBy(c => c.Location.Lat).Select(g => new
{
	Names = g.Select(c => c.Name),
	Lat = g.Key,
	Number = g.Count()
}).Where(x => x.Number > 1).OrderByDescending(x => x.Number);


foreach (var city in list)
{
	Console.WriteLine($"Lat:{city.Lat} Number:{city.Number} \nCity:");

	foreach (var name in city.Names)
	{
		Console.WriteLine(name);
	}
	Console.WriteLine();
}

class City
{
	public string Name { get; set; }
	public Location Location { get; set; }

	public City(string Name, Location loc)
	{
		this.Name = Name;
		this.Location = loc;
	}
};

class Location
{
	public double Lat { get; set; }
	public double Lon { get; set; }

	public Location(double lat, double lon)
	{
		this.Lat = lat;
		this.Lon = lon;
	}
};


//Version 2
/*

public class Program 
{
	public static void Main(string[] args)
	{
		List<City> cities = new List<City> {
			new City("Tokyo", new Location(11.120, 3)),
			new City("Delhi",new Location(12.120, 14.450)),
			new City("Shanghai", new Location(11.120, 14.550)),
			new City("São Paulo", new Location(14.120, 16.650)),
			new City("Mumbai", new Location(15.120, 17.750)),
			new City("Beijing", new Location(16.120, 14.850)),
			new City("Cairo",new Location(17.120, 14.0)),
			new City("Dhaka", new Location(18.120, 14.234)),
			new City("Osaka", new Location(17.120, 14.56)),
			new City("New York-Newark",new Location(18.120, 66.850)),
			new City("Karachi", new Location(120.120, 77.850)),
			new City("Chongqing", new Location(121.120, 88.850)),
			new City("Istanbul", new Location(122.120, 99.850)),

			new City("Kolkata", new Location(18.120, 14.850)),
			new City("Lagos", new Location(17.120, 14.368)),
			new City("Kinshasa", new Location(18.120, 14.342)),
			new City("Manila", new Location(18.720, 13.923)),
			new City("Rio de Janeiro", new Location(18.120, 13.374)),
			new City("Tianjin", new Location(13.215, 18.160))
			};
		
		var cityList = cities.GroupBy(c => c.loc.lat).OrderBy(x => x.Key);		

		foreach (var city in cityList)
		{			
			Console.WriteLine($"Latitude = {city.Key}");

			int i = 0;
			foreach (var c in city)
			{
				i++;
				Console.WriteLine(c.name);
			}

			Console.WriteLine(i + " cities");
		}

		Console.ReadKey();
	}
}

record City (string name, Location loc);
record Location(double lat, double lon);

*/
