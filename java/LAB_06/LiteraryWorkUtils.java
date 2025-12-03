import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

public class LiteraryWorkUtils {
    private static LiteraryWorkFactory factory = new NovelFactory();

    public static void setLiteraryWorkFactory(LiteraryWorkFactory f) {
        factory = f;
    }

    public static void sort(List<LiteraryWork> list) {
        if (list == null)
            return;
        Collections.sort(list);
    }

    public static void sort(LiteraryWork[] array, Comparator<LiteraryWork> comp) {
        Arrays.sort(array, comp);
    }

    public static LiteraryWork unmodifiable(LiteraryWork work) {
        return new UnmodifiableLiteraryWork(work);
    }

    public static LiteraryWork createInstance() {
        return factory.createInstance();
    }
}
