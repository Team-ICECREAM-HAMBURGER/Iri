public static class GameControlTypeManager {
    public enum vehicleType {
        TRAIN_PASSENGER_F,
        TRAIN_PASSENGER_R,
        TRAIN_FREIGHT,
        TRAIN_DANGEROUS
    }

    public enum TrafficStatus {
        MOVE,       // 출발
        STOP,       // 정차; 도착
        IDLE,       // 정차; 대기
        APPROACH,   // 접근
        PASS,       // 통과
    }

    public enum StampType {
        OK,
        NO
    }

    public enum StoryChapterType {
        STORY_NEW_IRI_MAN,
        STORY_YEONGDONG_FIN,
        //
        SUB_DRUG_COP_KILLER,
        SUB_FIREWORKS,
        SUB_HATE_SHARE,
        SUB_PABLO
    }

    public enum FamilyType {
        OLD_MOTHER,     // 0
        WIFE,           // 1
        EL_DAUGHTER,    // 2
        SEC_SON         // 3
        
        // EL_SON,         
        // SEC_DAUGHTER,
    }
    
    public enum FamilyStatusType {
        GOOD,       // 좋음 (Monitor)
        BAD,        // 위독 (Monitor)
        
        STARVING,   // 굶음 (Stack)
        SICK,       // 아픔 (Stack)
        COLD,       // 추움 (Stack)
        
        SAD,        // 슬픔 (Trigger)
        DIE,        // 사망 (Trigger)
    }
}