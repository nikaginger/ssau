import java.util.Comparator;

public class BusinessDescComparator implements Comparator<LiteraryWork> {
    @Override
    public int compare(LiteraryWork o1, LiteraryWork o2) {
        try {
            int v1 = o1.calculateUsefulPages();
            int v2 = o2.calculateUsefulPages();
            return Integer.compare(v2, v1);
        } catch (InvalidBookDataException e) {
            return 1;
        }
    }
}
