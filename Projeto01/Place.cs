namespace Projeto01;

public class Place
{
	private int _id;
	private string _name;
	private string _city;
	private string _country;

	public int Id
	{
		get { return _id; }
		set { _id = value; }
	}

	public string Name
	{
		get { return _name; }
		set
		{
			if (string.IsNullOrEmpty(value))
				throw new ArgumentNullException(nameof(Name), "Name cannot be null or empty.");
			_name = value;
		}
	}

	public string City
	{
		get { return _city; }
		set
		{
			if (string.IsNullOrEmpty(value))
				throw new ArgumentNullException(nameof(City), "City cannot be null or empty.");
			_city = value;
		}
	}

	public string Country
	{
		get { return _country; }
		set
		{
			if (string.IsNullOrEmpty(value))
				throw new ArgumentNullException(nameof(Country), "Country cannot be null or empty.");
			_country = value;
		}
	}
}