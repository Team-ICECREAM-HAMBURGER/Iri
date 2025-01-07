public class GameSaveDataFamily {
    public readonly string tag;
    public string familyName;
    public GameControlTypeManager.FamilyType familyType;
    public GameControlTypeManager.FamilyStatusType familyStatus;


    public GameSaveDataFamily(string tag, string familyName, GameControlTypeManager.FamilyType familyType, GameControlTypeManager.FamilyStatusType familyStatus) {
        this.tag = tag;
        this.familyName = familyName;
        this.familyType = familyType;
        this.familyStatus = familyStatus;
    }
}