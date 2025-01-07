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
}