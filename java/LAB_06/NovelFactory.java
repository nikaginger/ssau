import java.util.List;

public class NovelFactory implements LiteraryWorkFactory {
    @Override
    public LiteraryWork createInstance() {
        return new Novel("Новый роман", 0, List.of(0));
    }
}