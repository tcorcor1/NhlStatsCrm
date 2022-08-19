namespace NhlStatsCrm.Domain.Entities.Nhl
{
	[JsonObject("person")]
	public class Person
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("fullName")]
		public string FullName { get; set; }

		[JsonProperty("link")]
		public string Link { get; set; }
	}
}