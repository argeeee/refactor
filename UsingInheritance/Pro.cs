namespace Pro;

abstract record Player {
	public string Name { get; set; } = "";
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

record InGamePlayer : Player {
	public int LifePoints { get; set; }
	public required Position Position { get; set; }
	public required Weapon EquippedWeapon { get; set; }
}

class WeaponFactory {
	private readonly Dictionary<string, Weapon> weapons = [];

	public Weapon GetSword(int length, int damagePerHit) {
		string key = $"Sword_{length}_{damagePerHit}";
		if (!weapons.TryGetValue(key, out Weapon? value)) {
			value = new Sword { SwordLength = length, SwordDamagePerHit = damagePerHit };
			weapons[key] = value;
		}
		return value;
	}

	public Weapon GetAxeAndShield(int damagePerHit, int protection) {
		string key = $"AxeAndShield_{damagePerHit}_{protection}";
		if (!weapons.TryGetValue(key, out Weapon? value)) {
			value = new AxeAndShield { AxeDamagePerHit = damagePerHit, ShieldProtection = protection };
			weapons[key] = value;
		}
		return value;
	}
}

class InGamePlayerBuilder(string name) {
	readonly string _name = name;
	int _lifePoints;
	Position? _position;
	Weapon? _equippedWeapon;

	public InGamePlayerBuilder WithLifePoints(int lifePoints) {
		_lifePoints = lifePoints;
		return this;
	}

	public InGamePlayerBuilder WithPosition(int x, int y) {
		_position = new Position { X = x, Y = y };
		return this;
	}

	public InGamePlayerBuilder WithEquippedWeapon(Weapon weapon) {
		_equippedWeapon = weapon;
		return this;
	}

	public InGamePlayer Build() {
		if (_position == null || _equippedWeapon == null)
			throw new Exception("Position and EquippedWeapon can't be null");

		return new InGamePlayer {
			Name = _name,
			LifePoints = _lifePoints,
			Position = _position,
			EquippedWeapon = _equippedWeapon,
		};
	}
}

class Program {
	static void Main() {
		WeaponFactory weaponFactory = new();

		Weapon sword = weaponFactory.GetSword(30, 20);
		Weapon axeAndShield = weaponFactory.GetAxeAndShield(25, 15);

		InGamePlayer one = new InGamePlayerBuilder("One")
			.WithLifePoints(100)
			.WithPosition(10, 10)
			.WithEquippedWeapon(sword)
			.Build();

		InGamePlayer two = new InGamePlayerBuilder("Two")
			.WithLifePoints(150)
			.WithPosition(20, 20)
			.WithEquippedWeapon(axeAndShield)
			.Build();
		
		Console.WriteLine(one);
		Console.WriteLine(two);
	}
}