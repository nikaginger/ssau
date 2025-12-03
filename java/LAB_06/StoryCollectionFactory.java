import java.util.List;

public class StoryCollectionFactory implements LiteraryWorkFactory {
    @Override
    public LiteraryWork createInstance() {
        return new StoryCollection("Новый сборник", 0, List.of(0));
    }
}