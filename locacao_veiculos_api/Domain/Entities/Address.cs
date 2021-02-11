using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Address
{
	[Required]
	public string zipCode { get; set; }
	public string street { get; set; }
	public int number { get; set; }
	public string city { get; set; }
	public string state { get; set; }
}
