using System;

public class GameSaveDataChapter {
    public readonly string tag;
    public string chapterName;
    public GameControlTypeManager.ChapterType chapterType;
    public DateTime savedDateTime;
    
    
    public GameSaveDataChapter(string tag, string chapterName, 
        GameControlTypeManager.ChapterType chapterType, DateTime savedDateTime) {
        this.tag = tag;
        this.chapterName = chapterName;
        this.chapterType = chapterType;
        this.savedDateTime = savedDateTime;
    }

    public void ChapterUpdate(GameSaveDataChapterScriptableObject chapter) {
        this.chapterName = chapter.chapterName;
        this.chapterType = chapter.chapterType;
        this.savedDateTime = chapter.savedDateTime;
    }
}