import java.io.IOException;
import java.io.OutputStream;
import java.io.Writer;
import java.util.List;

public interface LiteraryWork {
    String getTitle();
    void setTitle(String title);

    int getServicePages();
    void setServicePages(int servicePages);

    List<Integer> getPageCounts();
    void setPageCounts(List<Integer> pageCounts);

    int getArrayElement(int index) throws IndexOutOfBoundsException;
    void setArrayElement(int index, int pages) throws IndexOutOfBoundsException;

    int calculateUsefulPages() throws InvalidBookDataException;

    // ЛАБА 4 тут
    void output(OutputStream out) throws IOException;
    void write(Writer out) throws IOException;
}