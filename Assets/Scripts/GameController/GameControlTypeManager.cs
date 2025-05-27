public static class GameControlTypeManager {
    public enum TrainType {
        TRAIN_PASSENGER_F,
        TRAIN_PASSENGER_R,
        TRAIN_FREIGHT,
        TRAIN_DANGEROUS
    }

    public enum TrainLocationType {
        MOVE,       // 출발
        STOP,       // 정차; 도착
        IDLE,       // 정차; 대기
    }

    public enum StampType {
        OK,
        NO
    }

    public enum NewsArticleType {
        STORY_NEW_IRI_MAN,
        STORY_YEONGDONG_FIN,
        //
        SUB_DRUG_COP_KILLER,
        SUB_FIREWORKS,
        SUB_HATE_SHARE,
        SUB_PABLO
    }

    public enum ChapterType {
        DAY0_0,
        DAY1_0,
        DAY2_0,
        DAY3_0,
        DAY4_0,
        DAY5_0,
        DAY6_0,
        DAY7_0,

        DAY8_0,
        DAY9_0,
        DAY10_0,
        DAY11_0,
        DAY12_0,
        DAY13_0,
        DAY14_0,

        DAY15_0,
        DAY16_0,
        DAY17_0,
        DAY18_0,
        DAY19_0,
        DAY20_0,
        DAY21_0,

        DAY22_0,
        DAY23_0,
        DAY24_0,
        DAY25_0,
        DAY26_0,
        DAY27_0,
        DAY28_0,
        DAY29_0,
        DAY30_0,
        DAY31_0,
    }

    public enum EventType {
        DAY7_1,
        DAY7_2,
        
        DAY14_1,
        DAY14_2,
        
        DAY21_1,
        DAY21_2,
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

    public enum PassengerType {
        PASSENGER_OK,
        PASSENGER_NO_TICKET,
        PASSENGER_FAKE_ID_CARD_NORMAL,
        PASSENGER_FAKE_ID_CARD_HIGH,
        PASSENGER_FAKE_CARGO_WEIGHT,
        PASSENGER_FAKE_CARGO_TYPE,
    }
    
    public enum ItemType {
        INSPECTION_LOG,
        INSPECTION_REPORT,
        ENTRY_PERMIT,
        VACCINATION_CERTIFICATE,
        ASYLUM_GRANT,
        ID_CARD_HIGH,
        ID_CARD_NORMAL,
        TICKET_PASSENGER,
        BOOK_BROWN,
        ZIPPO,
    }

    public enum ItemLabelType {
        NAME,
        TITLE,
        DOB,
        APPROVAL_NUMBER,
        PURPOSE,
        ADDRESS,
        DATE,
        CODE,
        HEIGHT,
        WEIGHT,
        GENDER,
        NOTE
    }
}