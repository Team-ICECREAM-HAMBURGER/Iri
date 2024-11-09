public static class GameControlTypeManager {
    public enum vehicleType {
        TRAIN_PASSENGER,
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
}