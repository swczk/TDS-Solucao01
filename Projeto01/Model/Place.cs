﻿namespace Projeto01.Model;

public class PlaceModel
{
	private int _id;
	private string _name;
	private string _city;
	private string _country;
	private string _description;
	private DateTime _dateVisited;

	public int PlaceID
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

	public string Description
	{
		get { return _description; }
		set { _description = value; }
	}

	public DateTime DateVisited
	{
		get { return _dateVisited; }
		set { _dateVisited = value; }
	}
}