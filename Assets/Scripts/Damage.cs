
public class Damage {

    public Damage(int amount, int referenceAmount) {
        this.amount = amount;
        this.referenceAmount = referenceAmount;
    }

    private int amount;
    private int referenceAmount;

    public int Amount {
        get {
            return amount;
        }
    }

    public int ReferenceAmount {
        get {
            return referenceAmount;
        }
    }

}