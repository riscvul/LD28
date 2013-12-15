public class PlayerCharacter : BaseCharacter {
	void Update() {
		Messenger<int, int>.Broadcast("PlayerHealthUpdate", 80, 100);
	}
	
}
