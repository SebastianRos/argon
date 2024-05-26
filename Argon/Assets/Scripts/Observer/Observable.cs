public interface Observable {
  public void Register(Observer observer);
  public void Unregister(Observer observer);
}