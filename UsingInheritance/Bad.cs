namespace Bad;

record Player {
	public string Name { get; set; } = "";

	public int LifePoints { get; set; }
	public int X { get; set; }
	public int Y { get; set; }

	// With sword
	public int? SwordLength { get; set; }
	public int? SwordDamagePerHit { get; set; }

	// With axe and shield
	public int? AxeDamagePerHit { get; set; }
	public int? ShieldProtection { get; set; }
}

class Program {
	public static void Main0() {
		// Non vald player
		var player = new Player {
			Name = "Player",
			SwordLength = 10,
			AxeDamagePerHit = 11,
		};
	}
}