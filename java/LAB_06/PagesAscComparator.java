import java.util.Comparator;

public class PagesAscComparator implements Comparator<LiteraryWork> {

    @Override
    public int compare(LiteraryWork o1, LiteraryWork o2) {
        return Integer.compare(o1.getServicePages(), o2.getServicePages());
    }
}