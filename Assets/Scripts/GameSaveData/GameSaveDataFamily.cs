public class GameSaveDataFamily {
    public readonly string fileName = "Family_Save_Data";
    public string familyName;
    public GameControlTypeManager.FamilyType familyType;
    public GameControlTypeManager.FamilyStatusType familyStatus;

    public void Init(string familyName, GameControlTypeManager.FamilyType familyType, GameControlTypeManager.FamilyStatusType familyStatus) {
        this.familyName = familyName;
        this.familyType = familyType;
        this.familyStatus = familyStatus;
    }
}