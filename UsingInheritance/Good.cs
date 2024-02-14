namespace Good;

record Player {
	public string Name { get; set; } = "";
	public int LifePoints { get; set; }
	public required Position Position { get; set; }
	public required Weapon EquippedWeapon { get; set; }
}

class Position {
	public int X { get; set; }
	public int Y { get; set; }
}

abstract class Weapon {}

class Sword : Weapon {
	public int? SwordLength { get; set; }
	public int? SwordDamagePerHit { get; set; }
}

class AxeAndShield : Weapon {
	public int? AxeDamagePerHit { get; set; }
	public int? ShieldProtection { get; set; }
}
